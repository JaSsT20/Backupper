using Backuper.Forms;

namespace Backuper;

internal static class Program
{
    /// <summary>
    /// Punto de entrada principal para la aplicación de configuración.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}