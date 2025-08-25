using System.ComponentModel.DataAnnotations.Schema;

namespace AXIS.App.Core.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedById { get; set; }
        
        [NotMapped]
        public ApplicationUser? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedById { get; set; }
        [NotMapped]
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
