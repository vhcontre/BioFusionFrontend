using AXIS.App.Core.Entities;
using AXIS.App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using AXIS.App.Core.Data;

namespace AXIS.App.Infrastructure.Repositories
{
    public class TaskRepository(ApplicationDbContext context) : ITaskRepository
    {
        //private readonly ApplicationDbContext _context;
        //public TaskRepository(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public async Task<IEnumerable<TaskPlan>> GetAllAsync()
        {            
            return await context.TaskPlans
                .Include(tp => tp.User)
                .ToListAsync();
        }

        public async Task<TaskPlan?> GetByIdAsync(int id)
        {
            return await context.TaskPlans.FindAsync(id);
        }

        public async Task AddAsync(TaskPlan task)
        {
            context.TaskPlans.Add(task);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskPlan task)
        {
            var original = await context.TaskPlans.FindAsync(task.Id);
            if (original != null)
            {
                original.Subject = task.Subject;
                original.Description = task.Description;
                original.Observation = task.Observation;
                original.StartTime = task.StartTime;
                original.EndTime = task.EndTime;
                original.IsAllDay = task.IsAllDay;
                original.IsBlock = task.IsBlock;
                original.Status = task.Status;
                original.UserId = task.UserId;
                original.Priority = task.Priority;
                original.TaskDate = task.TaskDate;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                context.TaskPlans.Remove(task);
                await context.SaveChangesAsync();
            }
        }        
    }
}
