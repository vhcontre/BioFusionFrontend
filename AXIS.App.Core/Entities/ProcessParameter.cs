using AXIS.App.Core.Enums;

namespace AXIS.App.Core.Entities;

public class ProcessParameter : AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    // Valor del parámetro
    public decimal Value { get; set; }

    // Unidad del parámetro (enum)
    public Unit Unit { get; set; }

    // Relación con el proceso
    public Guid ProcessId { get; set; }
        
    public Process? Process { get; set; }

    // Metadata opcional
    public decimal? MinValue { get; set; }
    public decimal? MaxValue { get; set; }
    public bool IsRequired { get; set; } = true;

    // Método auxiliar
    public string GetSummary()
    {
        return $"{Name} = {Value} {Unit}";
    }
}
