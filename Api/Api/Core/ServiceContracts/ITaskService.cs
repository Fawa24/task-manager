using Api.Core.DTO;

namespace Api.Core.ServiceContracts
{
	/// <summary>
	/// Interface for TaskService
	/// </summary>
	public interface ITaskService
	{
		/// <summary>
		/// Adds a task card to the board
		/// </summary>
		/// <param name="addRequest">Task card to add</param>
		/// <returns>Added task card int the form of TaskCardResponce</returns>
		public Task<TaskCardResponce> AddTaskCardAsync(TaskCardAddRequest addRequest);
		/// <summary>
		/// Returns all the task cards
		/// </summary>
		/// <returns>A list of TaskCardResponce with all the tasks</returns>
		public Task<List<TaskCardResponce>> GetTaskCardsAsync();
		/// <summary>
		/// Returns all the task cards from the certain list
		/// </summary>
		/// <param name="listId">Id of the list</param>
		/// <returns>A list of TaskCardResponce with all the tasks from the certain list</returns>
		public Task<List<TaskCardResponce>> GetTaskCardsFromTaskListAsync(Guid listId);
		/// <summary>
		/// Deletes a certain card from the board
		/// </summary>
		/// <param name="cardId">Id of the card we want to delete</param>
		/// <returns>True in case delition is succesfull and false if it is not</returns>
		public Task<bool> DeleteTaskCardAsync(Guid cardId);
		/// <summary>
		/// Edits already existed card
		/// </summary>
		/// <param name="updateRequest">Updated card</param>
		/// <returns>Updated card in the form of TaskCardResponce</returns>
		public Task<TaskCardResponce> EditTaskCardAsync(TaskCardUpdateRequest updateRequest);
		/// <summary>
		/// Returns a cart by provided CardId
		/// </summary>
		/// <param name="id">Id of the card we want to get</param>
		/// <returns>Matches card in the form of TaskCardResponce</returns>
		public Task<TaskCardResponce> GetCardByIdAsync(Guid id);
	}
}
