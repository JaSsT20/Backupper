namespace Backuper.Models;

public class BackupFileItem
{
    public string FileName { get; set; } = string.Empty;
    public string JobName { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public bool IsLocal { get; set; }
    public long FileSizeBytes { get; set; }
    public DateTime CreatedTime { get; set; }
    public string FullPath { get; set; } = string.Empty;
}
