import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  tasks:any[]=[{title:"pakistan",description:"A very Good conuntry"}]
  
  addTask(title:string, description:string){
    try{
    if (title && description){
    this.tasks.push({title:title,description:description})

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
