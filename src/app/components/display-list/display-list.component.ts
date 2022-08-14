import { Component, OnInit,Input } from '@angular/core';
import { TodoTask } from 'src/app/models/ToDoList';

@Component({
  selector: 'app-display-list',
  templateUrl: './display-list.component.html',
  styleUrls: ['./display-list.component.css']
})
export class DisplayListComponent implements OnInit {
  @Input() tasks!: TodoTask[];
  

  constructor() { }

  ngOnInit(): void {
  }
  deleteTask(index:number){
    console.log(index)
    this.tasks.splice(index,1)
  }

}
