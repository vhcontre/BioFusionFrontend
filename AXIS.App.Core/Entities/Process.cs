using AXIS.App.Core.Enums;


namespace AXIS.App.Core.Entities;

public class Process : AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Nombre y descripción
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    // Tipo de proceso
    public ProcessType Type { get; set; }

    // Lista de parámetros de proceso
    public ICollection<ProcessParameter> Parameters { get; set; } = [];

    // Relaciones con productos (muchos a muchos)
    public ICollection<Product> Products { get; set; } = [];

    // Metadata opcional avanzada
    public TimeSpan? ExpectedDuration { get; set; } // Duración estimada del proceso
    public double? Temperature { get; set; } // Temperatura óptima
    public double? PH { get; set; } // Valor de pH recomendado
    public string? Notes { get; set; } // Comentarios o información adicional

    // Método auxiliar opcional
    public string GetSummary()
    {
        return $"{Name} ({Type}) - Params: {Parameters.Count}";
    }
}
