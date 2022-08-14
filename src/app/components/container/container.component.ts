import { Component, OnInit } from '@angular/core';
import { TodoTask } from 'src/app/models/ToDoList';
@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent implements OnInit {
TaskList: TodoTask[]=[{title:"pakistan",description:"It is a good Country"}];
  constructor() { }

  ngOnInit(): void {
  }

}
