import { Component, OnInit,Input } from '@angular/core';
import { Employee } from '../../models/EmployeeDetail';
import { ManageEmployeeService } from '../../services/manage-employee.service';
@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {
@Input() emp!:Employee;
@Input() available!:boolean;
empList:Employee[]=this.manageEmployeeService.getEmployees()
empDetails!:Employee;
  constructor(private manageEmployeeService:ManageEmployeeService) {

   }

  ngOnInit(): void {
  }
  
  

}
