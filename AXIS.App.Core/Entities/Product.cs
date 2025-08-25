using AXIS.App.Core.Enums;

namespace AXIS.App.Core.Entities
{
    public class Product : AuditableEntity
    {
        // Identificaci�n b�sica
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!; // Unique product code
        
        public string Description { get; set; } = string.Empty;

        // Categor�a del producto
        public ProductCategory Category { get; set; } = ProductCategory.Other;

        // Estado y visibilidad
        public bool IsActive { get; set; } = true;
        public DateTime? DiscontinuedAt { get; set; }

        // Propiedades de biofabricaci�n
        public double? BaseYield { get; set; } // Rendimiento base esperado
        public double? NutritionalValue { get; set; } // Valor nutricional promedio
        public double? Cost { get; set; } // Costo estimado de producci�n
        public double? EnvironmentalImpact { get; set; } // Impacto ambiental estimado

        // Relaciones con otras entidades
        public ICollection<Variable> BaseVariables { get; set; } = [];
        public ICollection<Process> Processes { get; set; } = [];

        // Metadata opcional avanzada
        public string? Notes { get; set; } // Comentarios o informaci�n adicional
        public string? Supplier { get; set; } // Proveedor o fuente del producto
        public TimeSpan? ShelfLife { get; set; } // Vida �til aproximada

        // M�todo auxiliar opcional para mostrar info resumida
        public string GetSummary()
        {
            return $"{Name} ({Code}) - Category: {Category}, Active: {IsActive}";
        }
    }
}
