using System;
using System.Collections.Generic;

namespace Api.Core.Domain.Entities;

public partial class TaskCard
{
    public Guid Taskid { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Priority { get; set; }

    public Guid? Listid { get; set; }

    public virtual TaskList? List { get; set; }
}
