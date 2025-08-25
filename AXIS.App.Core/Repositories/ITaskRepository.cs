using System.Collections.Generic;
using System.Threading.Tasks;
using AXIS.App.Core.Entities;

namespace AXIS.App.Core.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskPlan>> GetAllAsync();
        Task<TaskPlan?> GetByIdAsync(int id);
        Task AddAsync(TaskPlan task);
        Task UpdateAsync(TaskPlan task);
        Task DeleteAsync(int id);
    }
}
