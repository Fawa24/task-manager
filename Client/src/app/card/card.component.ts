import { Component, Input } from '@angular/core';
import { TaskCard } from '../models/task-card';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})

export class CardComponent {
  @Input() taskCard!: TaskCard;
}
