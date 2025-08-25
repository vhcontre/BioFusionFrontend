using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AXIS.App.Core.Entities;

public class ApplicationUser : IdentityUser
{
    [Required] 
    public string FullName { get; set; } = string.Empty;

    [Required] 
    public string Area { get; set; } = string.Empty;

    [Required] 
    public string Photo { get; set; } = string.Empty;

    public ICollection<TaskPlan> TaskPlans { get; set; } = []; 
}
