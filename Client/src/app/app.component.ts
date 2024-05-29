import { Component } from '@angular/core';
import { TaskCard } from './models/task-card';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent{
  title = 'Client'; 

  taskCard: TaskCard = new TaskCard({
    TaskId: "123456",
    Name: "Complete Project Proposal",
    Description: "Write a detailed proposal outlining project scope, objectives, and deliverables.",
    DueDate: new Date("2024-06-15"),
    Priority: "High",
    ListId: "987654"
  })
}
