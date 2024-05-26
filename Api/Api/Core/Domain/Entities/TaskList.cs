using System;
using System.Collections.Generic;

namespace Api.Core.Domain.Entities;

public partial class TaskList
{
    public Guid Listid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TaskCard> TaskCards { get; set; } = new List<TaskCard>();
}
