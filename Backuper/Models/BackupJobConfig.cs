using System.Text.Json.Serialization;

namespace Backuper.Models;

public class BackupJobConfig
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;

    // SQL Server
    public string SqlServer { get; set; } = "localhost";
    public AuthType SqlAuthType { get; set; } = AuthType.Windows;
    public string? SqlUsername { get; set; }
    public string? SqlPasswordEncrypted { get; set; }
    public string DatabaseName { get; set; } = string.Empty;

    // Backup Settings
    public BackupType BackupType { get; set; } = BackupType.Full;
    public CompressionType Compression { get; set; } = CompressionType.Zip;
    public RetentionMode RetentionMode { get; set; } = RetentionMode.ByCount;
    public int RetentionCount { get; set; } = 10; // Mantener máximo N respaldos
    public int RetentionDays { get; set; } = 30;  // Eliminar respaldos más antiguos de X días
    public bool RetentionApplyLocal { get; set; } = true; // Aplicar limpieza en carpeta local
    public bool RetentionApplyCloud { get; set; } = true; // Aplicar limpieza en Dropbox
    public string LocalDestinationPath { get; set; } = string.Empty;

    // Cloud Integration (Optional)
    public bool EnableCloudUpload { get; set; } = false;
    public CloudProviderType CloudProvider { get; set; } = CloudProviderType.None;
    public string? CloudFolderPath { get; set; } = "/Backups";
    public string? CloudTokenEncrypted { get; set; }

    // Schedule Settings
    public FrequencyType Frequency { get; set; } = FrequencyType.Daily;
    public TimeSpan ExecutionTime { get; set; } = new TimeSpan(2, 0, 0); // 02:00 AM by default
    public List<DayOfWeek> WeeklyDays { get; set; } = new List<DayOfWeek> { DayOfWeek.Monday };
    public int DayOfMonth { get; set; } = 1;

    // Windows Credentials for Task Scheduler Logon
    public string? WindowsDomainOrMachine { get; set; }
    public string? WindowsUsername { get; set; }
    public string? WindowsPasswordEncrypted { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [JsonIgnore]
    public string BackupTypeDisplayName => BackupType switch
    {
        BackupType.Full => "Respaldo Completo",
        BackupType.Differential => "Respaldo Diferencial",
        BackupType.Log => "Log de Transacciones",
        _ => "Desconocido"
    };

    [JsonIgnore]
    public string FrequencyDisplayName => Frequency switch
    {
        FrequencyType.Daily => $"Diario a las {ExecutionTime:hh\\:mm}",
        FrequencyType.Weekly => $"Semanal ({string.Join(", ", WeeklyDays.Select(TranslateDay))}) a las {ExecutionTime:hh\\:mm}",
        FrequencyType.Monthly => $"El día {DayOfMonth} de cada mes a las {ExecutionTime:hh\\:mm}",
        _ => "Desconocido"
    };

    private static string TranslateDay(DayOfWeek day) => day switch
    {
        DayOfWeek.Monday => "Lun",
        DayOfWeek.Tuesday => "Mar",
        DayOfWeek.Wednesday => "Mié",
        DayOfWeek.Thursday => "Jue",
        DayOfWeek.Friday => "Vie",
        DayOfWeek.Saturday => "Sáb",
        DayOfWeek.Sunday => "Dom",
        _ => day.ToString()
    };
}
