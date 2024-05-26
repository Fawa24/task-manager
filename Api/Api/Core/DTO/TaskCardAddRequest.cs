using Api.Core.Domain.Entities;

namespace Api.Core.DTO
{
	public class TaskCardAddRequest
	{
		public string? Name { get; set; }

		public string? Description { get; set; }

		public DateOnly? DueDate { get; set; }

		public string? Priority { get; set; }

		public Guid? Listid { get; set; }

		public virtual TaskList? List { get; set; }

		public TaskCard ToTaskCard()
		{
			return new TaskCard() {
				Taskid = Guid.NewGuid(),
				Name = Name,
				Description = Description,
				DueDate = DueDate,
				Priority = Priority,
				Listid = Listid
				//TO DO: figure out how to assign the List property a value via ListId
			};
		}
	}
}
