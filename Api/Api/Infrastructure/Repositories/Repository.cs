using Api.Core.Domain.Entities;
using Api.Core.Domain.RepositoryContracts;
using Api.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Repositories
{
	public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _db;

        public TaskRepository(TaskDbContext taskDbContext)
        {
            _db = taskDbContext;
        }

        public async Task<TaskCard> AddTaskAsync(TaskCard taskCard)
        {
            await _db.TaskCards.AddAsync(taskCard);
            await _db.SaveChangesAsync();
            return taskCard;
        }

        public async Task<bool> DeleteTaskByIdAsync(Guid taskId)
        {
            TaskCard? taskCard = await _db.TaskCards.FirstOrDefaultAsync(task => task.Taskid == taskId);

            if (taskCard == null)
            {
                return false;
            }

            _db.TaskCards.Remove(taskCard);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskCard>> GetAllTasksAsync()
        {
            return await _db.TaskCards.ToListAsync();
        }

        public async Task<TaskCard> GetTaskByIdAsync(Guid taskId)
        {
            TaskCard? task = await _db.TaskCards.FirstOrDefaultAsync(t => t.Taskid == taskId);

            if (task == null) throw new ArgumentException("No task card was found");

            return task;
        }

		public async Task<List<TaskCard>> GetTasksFromTaskListAsync(Guid listId)
		{
            List<TaskCard> matchedTask = await _db.TaskCards.Where(task => task.Listid == listId).ToListAsync();

            return matchedTask;
		}

		public async Task<TaskCard> UpdateTaskAsync(TaskCard taskCard)
        {
            TaskCard? matchingTask = await _db.TaskCards.FirstOrDefaultAsync(task => task.Taskid == taskCard.Taskid);

            if (matchingTask == null) return taskCard;

            matchingTask.DueDate = taskCard.DueDate;
            matchingTask.Description = taskCard.Description;
            matchingTask.Name = taskCard.Name;
            matchingTask.Priority = taskCard.Priority;
            matchingTask.Listid = taskCard.Listid;

            await _db.SaveChangesAsync();

            return matchingTask;

        }


    }
}
