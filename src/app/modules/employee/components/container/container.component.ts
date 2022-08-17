import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/EmployeeDetail';
import { ManageEmployeeService } from '../../services/manage-employee.service';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent implements OnInit {
emp:any=this.manageEmployeeService.getEmpDetail(1).subscribe(data=>{this.emp=data})
available:boolean=false;
  constructor(private manageEmployeeService: ManageEmployeeService) {  }

  ngOnInit(): void {
  }

  setEmpIndex(e:Employee){
  this.available=true;
  this.emp=e;
  console.log(this.emp)
  }
}
