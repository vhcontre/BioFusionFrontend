using AXIS.App.Core.Enums;

namespace AXIS.App.Core.Entities;
public class TaskPlan : AuditableEntity
{
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public DateTime TaskDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAllDay { get; set; }
    public bool IsBlock { get; set; }
    public string Description { get; set; } = string.Empty;
    public AXIS.App.Core.Enums.TaskStatus Status { get; set; } = AXIS.App.Core.Enums.TaskStatus.Pending;
    public string? Observation { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int Priority { get; set; }
    public DateTime? DueDate { get; set; }

    // Tipo de tarea: Simulation, Experiment, Review, etc.
    public TaskType Type { get; set; } = TaskType.Simulation;

    // Relación opcional con procesos y variables para trazabilidad
    public List<Process>? Processes { get; set; } = [];
    public List<Variable>? Variables { get; set; } = [];

    // Para Syncfusion Schedule
    public ApplicationUser? User { get; set; }

    // Posibilidad de agregar logs o archivos en el futuro
    public List<TaskLog>? Logs { get; set; } = [];
}
