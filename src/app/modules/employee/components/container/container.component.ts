import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/EmployeeDetail';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent implements OnInit {
emp!:Employee;
available:boolean=false;
  constructor() { }

  ngOnInit(): void {
  }

  setEmp(e:Employee){
  this.available=true;
  this.emp=e ;
  console.log(e)
  }
}
