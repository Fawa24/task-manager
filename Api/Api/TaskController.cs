using Api.Core.DTO;
using Api.Core.ServiceContracts;
using Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
	[ApiController]
	public class TaskController : ControllerBase
	{
		private readonly ITaskService _taskService;

		public TaskController(ITaskService taskService) 
		{ 
			_taskService = taskService;
		}

		[HttpGet("/cards")]
		public async Task<ActionResult<List<TaskCardResponce>>> GetAllTaskCards()
		{
			List<TaskCardResponce> tasks = await _taskService.GetTaskCardsAsync();

			return tasks;
		}

		[HttpGet("/cards/{id}")]
		public async Task<ActionResult<TaskCardResponce>> GetTaskCardById(Guid taskId)
		{
			TaskCardResponce matchedTask = await _taskService.GetCardByIdAsync(taskId);

			return matchedTask;
		}

		[HttpPost("/cards")]
		public async Task<ActionResult> CreateTaskCard(TaskCardAddRequest taskCardAddRequest)
		{
			await _taskService.AddTaskCardAsync(taskCardAddRequest);
			return Created();
		}

		[HttpDelete("/cards/{id}")]
		public async Task<ActionResult> DeleteTaskCard(Guid taskId)
		{
			await _taskService.DeleteTaskCardAsync(taskId);

			return NoContent();
		}

		[HttpPatch("/cards/{id}")]
		public async Task<ActionResult> EditTaskCard(TaskCardUpdateRequest updatedTaskCard)
		{
			await _taskService.EditTaskCardAsync(updatedTaskCard);

			return NoContent();
		}
	}
}
