using Api.Core.Domain.Entities;
using System.Text.Json.Serialization;

namespace Api.Core.DTO
{
	public class TaskListResponce
	{
		public Guid Listid { get; set; }

		public string? Name { get; set; }

		public virtual ICollection<TaskCard> TaskCards { get; set; } = new List<TaskCard>();
	}

	public static class TaskListExtension
	{
		public static TaskListResponce ToTaskListResponce(this TaskList taskList)
		{
			return new TaskListResponce
			{
				Listid = taskList.Listid,
				Name = taskList.Name,
				TaskCards = taskList.TaskCards
			};
		}
	}
}
