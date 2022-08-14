import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  tasks:any[]=[{name:"pakistan"}]
  
  addTask(task:string){
    try{
    if (task){
    this.tasks.push({name:task})
    }
  }
  catch(e){
    window.alert(e)
  }
  }
  deleteTask(index:number){
    console.log(index)
    this.tasks.splice(index,1)
  }

}
