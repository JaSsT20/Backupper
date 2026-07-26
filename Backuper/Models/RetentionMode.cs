namespace Backuper.Models;

public enum RetentionMode
{
    ByCount, // Por Cantidad (p. ej., conservar máximo N respaldos)
    ByAge,   // Por Antigüedad (p. ej., eliminar respaldos con más de X días)
    Both     // Ambos combinados (Eliminar los de más de X días Y limitar a máximo N respaldos)
}
