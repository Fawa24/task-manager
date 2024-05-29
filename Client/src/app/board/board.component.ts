import { Component, OnInit } from '@angular/core';
import { TaskList } from '../models/task-list';
import { TaskService } from '../Task/task.service';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrl: './board.component.css'
})
export class BoardComponent implements OnInit {
  lists: TaskList[] = []

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.taskService.getTaskLists().subscribe(data => {
      this.lists = data
    })
  }
}
