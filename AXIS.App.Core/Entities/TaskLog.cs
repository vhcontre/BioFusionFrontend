using AXIS.App.Core.Enums;

namespace AXIS.App.Core.Entities;

public class TaskLog : AuditableEntity
{
    public int Id { get; set; }

    // Relación con la tarea principal
    public int TaskPlanId { get; set; }
    public TaskPlan? TaskPlan { get; set; }

    // Fecha y hora del registro
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    // Tipo de acción realizada en la tarea
    public TaskType TaskType { get; set; }

    // Notas o detalles del registro, ejemplo: resultados, observaciones, cambios
    public string? Notes { get; set; }

    // Usuario que realizó la acción
    public string? PerformedById { get; set; }
    public ApplicationUser? PerformedBy { get; set; }

    // Nuevo estado de la tarea si aplica (opcional)
    public AXIS.App.Core.Enums.TaskStatus? NewStatus { get; set; }

    // Ruta opcional de archivos asociados al log (documentación, imágenes, resultados)
    public string? FilePath { get; set; }
}

