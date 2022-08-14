import { Component, OnInit,Input,Output, EventEmitter } from '@angular/core';
import { TodoTask } from 'src/app/models/ToDoList';

@Component({
  selector: 'app-add-to-list',
  templateUrl: './add-to-list.component.html',
  styleUrls: ['./add-to-list.component.css']
})
export class AddToListComponent implements OnInit {
  @Input() tasks!: TodoTask[];
title:string='';
description:string='';
  constructor() { }

  ngOnInit(): void {
  }
  titleVal(e:string){
    this.title=e;
  }
  descriptionVal(e:string){
    this.description=e;
  }
  addTask(){
    console.log(this.title,this.description)
    this.tasks.push({title:this.title,description:this.description})
  }

}
