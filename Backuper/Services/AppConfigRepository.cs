using System.Text.Json;
using Backuper.Models;

namespace Backuper.Services;

public class AppConfigRepository
{
    private readonly string _filePath;

    public AppConfigRepository()
    {
        string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Backuper");
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        _filePath = Path.Combine(folder, "app_settings.json");
    }

    public async Task<AppConfig> LoadAsync()
    {
        if (!File.Exists(_filePath))
        {
            return new AppConfig();
        }

        try
        {
            string json = await File.ReadAllTextAsync(_filePath);
            var config = JsonSerializer.Deserialize<AppConfig>(json);
            return config ?? new AppConfig();
        }
        catch
        {
            return new AppConfig();
        }
    }

    public async Task SaveAsync(AppConfig config)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(config, options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
