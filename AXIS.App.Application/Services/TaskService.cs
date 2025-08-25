using AXIS.App.Core.Data;
using AXIS.App.Core.Entities;
using AXIS.App.Core.Repositories;
using AXIS.App.Shared;
using Microsoft.EntityFrameworkCore;
using CoreTaskStatus = AXIS.App.Core.Entities.TaskStatus;

namespace AXIS.App.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ApplicationDbContext _context;

        public TaskService(ITaskRepository taskRepository, ApplicationDbContext context)
        {
            _taskRepository = taskRepository;
            _context = context;
        }

        public async Task<IEnumerable<TaskPlan>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<TaskPlan?> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task AddTaskAsync(TaskPlan task)
        {
            await _taskRepository.AddAsync(task);                        
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskPlan task)
        {
            var original = await _taskRepository.GetByIdAsync(task.Id);            
            await _taskRepository.UpdateAsync(task);            
            await _context.SaveChangesAsync();
        }
        
        // Obtener tareas (TaskPlan) paginadas y el total, excluyendo las tareas de bloque (almuerzo)
        public async Task<(List<TaskPlanViewModel> tasks, int total)> GetTasksAsync(int skip, int take)
        {
            // Filtrar para excluir las tareas de bloque (IsBlock = true)
            var query = _context.TaskPlans.Include(t => t.User)
                //.Where(t => !t.IsBlock)
                .OrderBy(t => t.StartTime);
            // Calcular el total de tareas válidas (sin bloque)
            var total = await query.CountAsync();
            // Obtener la página de entidades desde la base de datos
            var entities = await query
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            // Mapear a ViewModel en memoria (C#)
            var tasks = entities
                .Select(t => ToViewModel(t))
                .ToList();
            return (tasks, total);
        }

        // Crear una nueva tarea a partir del ViewModel
        public async Task<TaskPlanViewModel> CreateTaskAsync(TaskPlanViewModel model)
        {
            // Forzar el tipo Local, pero NO convertir la hora (evita desfases)
            model.StartTime = DateTime.SpecifyKind(model.StartTime, DateTimeKind.Local);
            model.EndTime = DateTime.SpecifyKind(model.EndTime, DateTimeKind.Local);

            var entity = FromViewModel(model);
            await _taskRepository.AddAsync(entity);
            await _context.SaveChangesAsync();
            var created = await _context.TaskPlans.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == entity.Id);
            return ToViewModel(created!);
        }

        
        public async Task<TaskPlanViewModel?> UpdateTaskAsync(TaskPlanViewModel model)
        {
            var entity = await _context.TaskPlans.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == model.Id);
            if (entity == null)
                return null;

            var taskStatus = Enum.TryParse<CoreTaskStatus>(model.Status, out var status) ? status : CoreTaskStatus.Pending;
            entity = FromViewModel(model);
            
            await _taskRepository.UpdateAsync(entity);
            
            await _context.SaveChangesAsync();

            return ToViewModel(entity);

        }

        
        public async Task<bool> DeleteTaskAsync(int id)
        {
            var entity = await _context.TaskPlans.FindAsync(id);
            if (entity == null)
                return false;
            await _taskRepository.DeleteAsync(id);
            await _context.SaveChangesAsync();
            return true;
        }

        
        // Verifica si un usuario existe por su ID
        public async Task<bool> UserExistsAsync(string userId)
        {
            return await _context.Users.AnyAsync(u => u.Id == userId);
        }

        // Mapeo de entidad a ViewModel
        private TaskPlanViewModel ToViewModel(TaskPlan t)
        {
            // No convertir fechas, devolver tal cual están en la base de datos
            return new TaskPlanViewModel
            {
                Id = t.Id,
                Subject = t.Subject,
                StartTime = t.StartTime,
                EndTime = t.EndTime,
                IsAllDay = t.IsAllDay,
                IsBlock = t.IsBlock,
                Observation = t.Observation ?? string.Empty,
                Description = t.Description,
                Priority = t.Priority,                
                Photo = t.User != null ? t.User.Photo : string.Empty,                
                Status = t.Status.ToString()                
            };
        }

        // Mapeo de ViewModel a entidad
        private TaskPlan FromViewModel(TaskPlanViewModel model)
        {
            // Asignar TaskDate usando la fecha de StartTime (ya normalizada)
            return new TaskPlan
            {
                Id = model.Id,
                Subject = model.Subject,
                TaskDate = model.StartTime.Date, // Asignar la fecha base
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                IsAllDay = model.IsAllDay,
                IsBlock = model.IsBlock,
                Observation = model.Observation,
                Description = model.Description,
                Priority = model.Priority,
                UserId = model.UserId,
                Status = Enum.TryParse<CoreTaskStatus>(model.Status, out var status) ? status : CoreTaskStatus.Pending,
                DueDate = null
            };
        }
    }

}
