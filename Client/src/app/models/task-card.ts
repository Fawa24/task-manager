export class TaskCard {
    TaskId: string;
    Name: string;
    Description: string;
    DueDate: Date;
    Priority: string;
    ListId: string;
  
    constructor(data: {
      TaskId: string,
      Name: string,
      Description: string,
      DueDate: Date,
      Priority: string,
      ListId: string
    }) {
      this.TaskId = data.TaskId;
      this.Name = data.Name;
      this.Description = data.Description;
      this.DueDate = data.DueDate;
      this.Priority = data.Priority;
      this.ListId = data.ListId;
    }
  }
  