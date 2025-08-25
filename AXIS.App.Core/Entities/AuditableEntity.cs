namespace AXIS.App.Core.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedById { get; set; }
                
        public ApplicationUser? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedById { get; set; }        
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
