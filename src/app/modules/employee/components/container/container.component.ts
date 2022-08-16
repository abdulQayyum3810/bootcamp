import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/EmployeeDetail';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent implements OnInit {
empIndex!:number;
available:boolean=false;
  constructor() { }

  ngOnInit(): void {
  }

  setEmpIndex(e:Employee){
  this.available=true;
  this.empIndex=e.Id ;
  console.log(this.empIndex)
  }
}
