using System;

namespace AXIS.App.Shared
{
    
    public class TaskPlanViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsBlock { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Observation { get; set; } = string.Empty;
        public int Priority { get; set; }        
        public string Status { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
