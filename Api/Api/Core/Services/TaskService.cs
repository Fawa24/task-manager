using Api.Core.Domain.Entities;
using Api.Core.Domain.RepositoryContracts;
using Api.Core.DTO;
using Api.Core.ServiceContracts;
using Api.Infrastructure.Repositories;

namespace Api.Core.Services
{
	public class TaskService : ITaskService
	{
		private readonly ITaskRepository _taskRepository;

		public TaskService(ITaskRepository taskRepository) 
		{
			_taskRepository = taskRepository;
		}

		public async Task<TaskCardResponce> AddTaskCardAsync(TaskCardAddRequest addRequest)
		{
			TaskCard task = addRequest.ToTaskCard();

			TaskCardResponce addedCard = (await _taskRepository.AddTaskAsync(task)).ToTaskCardResponce();

			return addedCard;
		}

		public async Task<bool> DeleteTaskCardAsync(Guid cardId)
		{
			return await _taskRepository.DeleteTaskByIdAsync(cardId);
		}

		public async Task<TaskCardResponce> EditTaskCardAsync(TaskCardUpdateRequest updateRequest)
		{
			TaskCard taskToUpdate = updateRequest.ToTaskCard();

			TaskCardResponce updatedCard = (await _taskRepository.UpdateTaskAsync(taskToUpdate)).ToTaskCardResponce();

			return updatedCard;
		}

		public async Task<TaskCardResponce> GetCardByIdAsync(Guid id)
		{
			TaskCardResponce matchedCard = (await _taskRepository.GetTaskByIdAsync(id)).ToTaskCardResponce();

			return matchedCard;
		}

		public async Task<List<TaskCardResponce>> GetTaskCardsAsync()
		{
			List<TaskCardResponce> tasks = (await _taskRepository.GetAllTasksAsync()).Select(task => task.ToTaskCardResponce()).ToList();

			return tasks;
		}

		public async Task<List<TaskCardResponce>> GetTaskCardsFromTaskListAsync(Guid listId)
		{
			List<TaskCardResponce> tasks = (await _taskRepository.GetTasksFromTaskListAsync(listId)).Select(task => task.ToTaskCardResponce()).ToList();

			return tasks;
		}
	}
}
