using AXIS.App.Core.Enums;

namespace AXIS.App.Core.Entities;

public class TaskLog : AuditableEntity
{
    public int Id { get; set; }

    // Relaci�n con la tarea principal
    public int TaskPlanId { get; set; }
    public TaskPlan? TaskPlan { get; set; }

    // Fecha y hora del registro
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    // Tipo de acci�n realizada en la tarea
    public TaskType TaskType { get; set; }

    // Notas o detalles del registro, ejemplo: resultados, observaciones, cambios
    public string? Notes { get; set; }

    // Usuario que realiz� la acci�n
    public string? PerformedById { get; set; }
    public ApplicationUser? PerformedBy { get; set; }

    // Nuevo estado de la tarea si aplica (opcional)
    public AXIS.App.Core.Enums.TaskStatus? NewStatus { get; set; }

    // Ruta opcional de archivos asociados al log (documentaci�n, im�genes, resultados)
    public string? FilePath { get; set; }
}

