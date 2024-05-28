using Api.Core.Domain.Entities;

namespace Api.Core.Domain.RepositoryContracts
{
	/// <summary>
	/// TaskRepository interface
	/// </summary>
	public interface ITaskRepository
	{	
		/// <summary>
		/// Adds task card to the data store
		/// </summary>
		/// <param name="taskCard">Task card to add</param>
		/// <returns>Added task card</returns>
		public Task<TaskCard> AddTask(TaskCard taskCard);
		
		/// <summary>
		/// Returns all the task cards from the data store
		/// </summary>
		/// <returns>List of task cards</returns>
		public Task<List<TaskCard>> GetAllTasks();
		
		/// <summary>
		/// Returns task with specified id
		/// </summary>
		/// <param name="taskId">Id to search</param>
		/// <returns>Matched task</returns>
		public Task<TaskCard> GetTaskById(Guid taskId);
		
		/// <summary>
		/// Deletes task with specified id
		/// </summary>
		/// <param name="taskId">Id of the task to delete</param>
		/// <returns>True is delition is succesfull or False if it is not</returns>
		public Task<bool> DeleteTaskById(Guid taskId);
		
		/// <summary>
		/// Updates existed task
		/// </summary>
		/// <param name="taskCard">Task object to update</param>
		/// <returns>Updated task</returns>
		public Task<TaskCard> UpdateTask(TaskCard taskCard);
	}
}
