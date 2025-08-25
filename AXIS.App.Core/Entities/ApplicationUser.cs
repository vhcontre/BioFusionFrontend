using Microsoft.AspNetCore.Identity;

namespace AXIS.App.Core.Entities;

// Técnico/Operario
public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string Area { get; set; } = string.Empty;    
    public string Photo { get; set; } = string.Empty;

    public ICollection<TaskPlan> TaskPlans { get; set; } = []; 
}
