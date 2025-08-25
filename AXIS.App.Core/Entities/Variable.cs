using AXIS.App.Core.Enums;

namespace AXIS.App.Core.Entities;

public class Variable : AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    // Tipo de variable: Base o Extended
    public VariableType Type { get; set; }

    // Unidad de medida (enum)
    public Unit Unit { get; set; }

    // Valor inicial o por defecto
    public decimal DefaultValue { get; set; }

    // Metadata opcional
    public decimal? MinValue { get; set; }
    public decimal? MaxValue { get; set; }
    public bool IsRequired { get; set; } = true;

    // Relación con producto (si corresponde)
    public Guid? ProductId { get; set; }
        
    public Product? Product { get; set; }

    // Método auxiliar
    public string GetSummary()
    {
        return $"{Name} ({Type}) = {DefaultValue} {Unit}";
    }
}
