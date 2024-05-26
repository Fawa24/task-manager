using Api.Core.Domain.Entities;

namespace Api.Core.DTO
{
	public class TaskCardResponce
	{
		public Guid Taskid { get; set; }

		public string? Name { get; set; }

		public string? Description { get; set; }

		public DateOnly? DueDate { get; set; }

		public string? Priority { get; set; }

		public Guid? Listid { get; set; }

		public virtual TaskList? List { get; set; }
	}

	public static class TaskCardExtension
	{
		public static TaskCardResponce ToTaskCardResponce(this TaskCard taskCard)
		{
			return new TaskCardResponce
			{
				Taskid = taskCard.Taskid,
				Name = taskCard.Name,
				Description = taskCard.Description,
				DueDate = taskCard.DueDate,
				Priority = taskCard.Priority,
				Listid = taskCard.Listid,
				List = taskCard.List
			};
		}
	}
}
