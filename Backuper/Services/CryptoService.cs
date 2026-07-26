using System.Security.Cryptography;
using System.Text;

namespace Backuper.Services;

public static class CryptoService
{
    // Usamos LocalMachine para que BackupWorker.exe pueda descifrar la configuración independientemente de la cuenta
    private static readonly DataProtectionScope Scope = DataProtectionScope.LocalMachine;

    /// <summary>
    /// Cifra un texto plano en Base64 utilizando DPAPI de Windows.
    /// </summary>
    public static string? Encrypt(string? plainText)
    {
        if (string.IsNullOrEmpty(plainText))
            return null;

        try
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherBytes = ProtectedData.Protect(plainBytes, null, Scope);
            return Convert.ToBase64String(cipherBytes);
        }
        catch
        {
            // Retorna nulo o lanza la excepción según necesidad
            return null;
        }
    }

    /// <summary>
    /// Descifra una cadena cifrada en Base64 utilizando DPAPI de Windows.
    /// </summary>
    public static string? Decrypt(string? cipherText)
    {
        if (string.IsNullOrEmpty(cipherText))
            return null;

        try
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] plainBytes = ProtectedData.Unprotect(cipherBytes, null, Scope);
            return Encoding.UTF8.GetString(plainBytes);
        }
        catch
        {
            return null;
        }
    }
}
