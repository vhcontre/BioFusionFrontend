using System;
using System.Collections.Generic;

namespace AXIS.App.Core.Entities
{
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
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public string? Observation { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int Priority { get; set; }
        public DateTime? DueDate { get; set; }

        public ApplicationUser? User { get; set; }        

    }

}
