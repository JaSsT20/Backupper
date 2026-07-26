using System.Text.Json;
using Backuper.Models;

namespace Backuper.Services;

public class JobConfigRepository
{
    private static readonly string FolderPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
        "Backuper",
        "jobs"
    );

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true
    };

    public JobConfigRepository()
    {
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }
    }

    public string GetJobFilePath(Guid jobId) => Path.Combine(FolderPath, $"{jobId}.json");

    public async Task<List<BackupJobConfig>> GetAllAsync()
    {
        var jobs = new List<BackupJobConfig>();

        if (!Directory.Exists(FolderPath))
            return jobs;

        var files = Directory.GetFiles(FolderPath, "*.json");
        foreach (var file in files)
        {
            try
            {
                string json = await File.ReadAllTextAsync(file);
                var job = JsonSerializer.Deserialize<BackupJobConfig>(json, _jsonOptions);
                if (job != null)
                {
                    jobs.Add(job);
                }
            }
            catch
            {
                // Ignorar archivos corruptos o ilegibles
            }
        }

        return jobs.OrderByDescending(j => j.UpdatedAt).ToList();
    }

    public async Task<BackupJobConfig?> GetByIdAsync(Guid jobId)
    {
        string filePath = GetJobFilePath(jobId);
        if (!File.Exists(filePath))
            return null;

        try
        {
            string json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<BackupJobConfig>(json, _jsonOptions);
        }
        catch
        {
            return null;
        }
    }

    public async Task SaveAsync(BackupJobConfig config)
    {
        config.UpdatedAt = DateTime.Now;
        string filePath = GetJobFilePath(config.Id);
        string json = JsonSerializer.Serialize(config, _jsonOptions);
        await File.ReadAllTextAsync(filePath).ContinueWith(_ => { }); // Dummy wait if needed
        await File.WriteAllTextAsync(filePath, json);
    }

    public Task DeleteAsync(Guid jobId)
    {
        string filePath = GetJobFilePath(jobId);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        return Task.CompletedTask;
    }
}
