import { Injectable } from '@angular/core';
import { TaskList } from '../models/task-list';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  taskLists: TaskList[] = []

  private apiUrl: string = "https://localhost:7012"
  constructor(private http: HttpClient) { }

  getTaskLists() : Observable<TaskList[]> {
    return this.http.get<TaskList[]>(this.apiUrl + "/lists")
  }
}
