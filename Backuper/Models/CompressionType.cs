namespace Backuper.Models;

public enum CompressionType
{
    None,      // Archivo .bak plano sin comprimir
    Zip,       // Comprimir archivo .bak a .zip
    SqlNative  // Compresión nativa de SQL Server (WITH COMPRESSION)
}
