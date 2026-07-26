namespace Backuper.Models;

public class AppConfig
{
    public string DefaultSqlServer { get; set; } = "localhost";
    public AuthType DefaultSqlAuthType { get; set; } = AuthType.Windows;
    public string? DefaultSqlUsername { get; set; }
    public string? DefaultSqlPasswordEncrypted { get; set; }
    public string? DefaultDatabaseName { get; set; }

    public string DefaultLocalDestinationPath { get; set; } = @"C:\BackupsSQL";
    public BackupType DefaultBackupType { get; set; } = BackupType.Full;
    public CompressionType DefaultCompression { get; set; } = CompressionType.Zip;

    public bool DefaultEnableCloudUpload { get; set; } = false;
    public CloudProviderType DefaultCloudProvider { get; set; } = CloudProviderType.Dropbox;
    public string DefaultCloudFolderPath { get; set; } = "/Backups";
    public string? DefaultCloudTokenEncrypted { get; set; }

    public string? DefaultWindowsDomainOrMachine { get; set; } = Environment.UserDomainName;
    public string? DefaultWindowsUsername { get; set; } = Environment.UserName;
    public string? DefaultWindowsPasswordEncrypted { get; set; }
}
