using Backuper.Models;
using Microsoft.Win32.TaskScheduler;

namespace Backuper.Services;

public class TaskSchedulerInfo
{
    public string TaskName { get; set; } = string.Empty;
    public bool Exists { get; set; }
    public string Status { get; set; } = "No Creada";
    public DateTime? LastRunTime { get; set; }
    public DateTime? NextRunTime { get; set; }
    public int LastTaskResult { get; set; }
}

public class TaskSchedulerService
{
    private const string TaskPrefix = "Backuper_Job_";

    public static string GetTaskName(Guid jobId) => $"{TaskPrefix}{jobId:N}";

    public static string DefaultWorkerPath
    {
        get
        {
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string primaryPath = Path.Combine(appDir, "BackupWorker.exe");
            if (File.Exists(primaryPath))
                return primaryPath;

            // Soporte para desarrollo en Visual Studio (cuando BackupWorker está en la carpeta de la solución)
            string solutionDevPath = Path.GetFullPath(Path.Combine(appDir, @"..\..\..\..\BackupWorker\bin\Debug\net8.0-windows\BackupWorker.exe"));
            if (File.Exists(solutionDevPath))
                return solutionDevPath;

            return primaryPath;
        }
    }

    /// <summary>
    /// Crea o actualiza una tarea en el Task Scheduler de Windows.
    /// </summary>
    public (bool Success, string Message) CreateOrUpdateTask(BackupJobConfig config, string? customWorkerPath = null)
    {
        try
        {
            using var ts = new TaskService();
            string taskName = GetTaskName(config.Id);
            TaskDefinition td = ts.NewTask();

            td.RegistrationInfo.Description = $"Respaldo Automático SQL Server [{config.Name}] - BD: {config.DatabaseName} ({config.BackupTypeDisplayName})";
            td.RegistrationInfo.Author = "Backuper";

            // Configuraciones de energía y ejecución
            td.Settings.DisallowStartIfOnBatteries = false;
            td.Settings.StopIfGoingOnBatteries = false;
            td.Settings.AllowDemandStart = true;
            td.Settings.Enabled = config.IsActive;
            td.Settings.ExecutionTimeLimit = TimeSpan.FromHours(4); // Tiempo máximo de ejecución
            td.Settings.StartWhenAvailable = true; // Si se pierde la hora programada, ejecutar al iniciar

            // Acción: Ejecutar BackupWorker.exe con los argumentos correspondientes
            string workerExePath = string.IsNullOrWhiteSpace(customWorkerPath) ? DefaultWorkerPath : customWorkerPath;
            string workerDir = Path.GetDirectoryName(workerExePath) ?? AppDomain.CurrentDomain.BaseDirectory;
            string jobFilePath = new JobConfigRepository().GetJobFilePath(config.Id);

            td.Actions.Add(new ExecAction(
                workerExePath,
                $"--job-id {config.Id} --config \"{jobFilePath}\"",
                workerDir
            ));

            // Trigger (Disparador) según la frecuencia
            DateTime startBoundary = DateTime.Today.Add(config.ExecutionTime);
            if (startBoundary <= DateTime.Now)
            {
                startBoundary = startBoundary.AddDays(1);
            }

            switch (config.Frequency)
            {
                case FrequencyType.Daily:
                    var dailyTrigger = new DailyTrigger { DaysInterval = 1, StartBoundary = startBoundary };
                    td.Triggers.Add(dailyTrigger);
                    break;

                case FrequencyType.Weekly:
                    DaysOfTheWeek daysOfWeek = 0;
                    if (config.WeeklyDays != null && config.WeeklyDays.Any())
                    {
                        foreach (var day in config.WeeklyDays)
                        {
                            if (Enum.TryParse<DaysOfTheWeek>(day.ToString(), out var dow))
                            {
                                daysOfWeek |= dow;
                            }
                        }
                    }
                    if (daysOfWeek == 0) daysOfWeek = DaysOfTheWeek.Monday;

                    var weeklyTrigger = new WeeklyTrigger { DaysOfWeek = daysOfWeek, WeeksInterval = 1, StartBoundary = startBoundary };
                    td.Triggers.Add(weeklyTrigger);
                    break;

                case FrequencyType.Monthly:
                    int dayOfMonth = Math.Clamp(config.DayOfMonth, 1, 31);
                    var monthlyTrigger = new MonthlyTrigger
                    {
                        DaysOfMonth = new[] { dayOfMonth },
                        MonthsOfYear = MonthsOfTheYear.AllMonths,
                        StartBoundary = startBoundary
                    };
                    td.Triggers.Add(monthlyTrigger);
                    break;
            }

            // Credenciales de Windows para ejecución desatendida (TaskLogonType.Password)
            string? windowsPassword = CryptoService.Decrypt(config.WindowsPasswordEncrypted);
            string? userAccount = config.WindowsUsername;

            if (!string.IsNullOrWhiteSpace(config.WindowsDomainOrMachine) && !string.IsNullOrWhiteSpace(userAccount))
            {
                if (!userAccount.Contains('\\') && !userAccount.Contains('@'))
                {
                    userAccount = $"{config.WindowsDomainOrMachine}\\{userAccount}";
                }
            }

            if (!string.IsNullOrWhiteSpace(userAccount) && !string.IsNullOrWhiteSpace(windowsPassword))
            {
                td.Principal.LogonType = TaskLogonType.Password;
                ts.RootFolder.RegisterTaskDefinition(
                    taskName,
                    td,
                    TaskCreation.CreateOrUpdate,
                    userAccount,
                    windowsPassword,
                    TaskLogonType.Password
                );
            }
            else
            {
                // Si no se proporcionaron credenciales completas de Windows, registrar con InteractiveToken (requerirá sesión activa)
                td.Principal.LogonType = TaskLogonType.InteractiveToken;
                ts.RootFolder.RegisterTaskDefinition(
                    taskName,
                    td,
                    TaskCreation.CreateOrUpdate,
                    null,
                    null,
                    TaskLogonType.InteractiveToken
                );
            }

            return (true, "La tarea fue registrada en el Programador de Tareas de Windows correctamente.");
        }
        catch (Exception ex)
        {
            return (false, $"Error al registrar la tarea en Task Scheduler: {ex.Message}");
        }
    }

    /// <summary>
    /// Elimina una tarea programada del Task Scheduler de Windows.
    /// </summary>
    public (bool Success, string Message) DeleteTask(Guid jobId)
    {
        try
        {
            using var ts = new TaskService();
            string taskName = GetTaskName(jobId);
            var task = ts.RootFolder.Tasks.FirstOrDefault(t => t.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                ts.RootFolder.DeleteTask(taskName);
                return (true, "Tarea eliminada de Windows Scheduler.");
            }
            return (true, "La tarea no existía en Windows Scheduler.");
        }
        catch (Exception ex)
        {
            return (false, $"Error al eliminar la tarea: {ex.Message}");
        }
    }

    /// <summary>
    /// Dispara inmediatamente la tarea de Windows.
    /// </summary>
    public (bool Success, string Message) RunTaskNow(Guid jobId)
    {
        try
        {
            using var ts = new TaskService();
            string taskName = GetTaskName(jobId);
            var task = ts.RootFolder.Tasks.FirstOrDefault(t => t.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                task.Run();
                return (true, "Se envió la señal de ejecución inmediata a la tarea.");
            }
            return (false, "No se encontró la tarea en el Programador de Tareas de Windows.");
        }
        catch (Exception ex)
        {
            return (false, $"Error al ejecutar la tarea: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtiene información de estado de la tarea en el Programador de Tareas.
    /// </summary>
    public TaskSchedulerInfo GetTaskInfo(Guid jobId)
    {
        var info = new TaskSchedulerInfo
        {
            TaskName = GetTaskName(jobId)
        };

        try
        {
            using var ts = new TaskService();
            var task = ts.RootFolder.Tasks.FirstOrDefault(t => t.Name.Equals(info.TaskName, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                info.Exists = true;
                info.Status = task.State switch
                {
                    TaskState.Ready => "Lista",
                    TaskState.Running => "En ejecución",
                    TaskState.Disabled => "Deshabilitada",
                    TaskState.Queued => "En cola",
                    _ => task.State.ToString()
                };
                info.LastRunTime = task.LastRunTime == DateTime.MinValue ? null : task.LastRunTime;
                info.NextRunTime = task.NextRunTime == DateTime.MinValue ? null : task.NextRunTime;
                info.LastTaskResult = task.LastTaskResult;
            }
        }
        catch
        {
            info.Status = "Error al leer estado";
        }

        return info;
    }
}
