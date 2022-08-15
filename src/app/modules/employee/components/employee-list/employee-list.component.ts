import { Component, EventEmitter, OnInit,Output } from '@angular/core';
import { Employee } from '../../models/EmployeeDetail';
import { ManageEmployeeService } from '../../services/manage-employee.service';
@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  @Output() selectedEmp= new EventEmitter<Employee>();
  empList!:Employee[];
  constructor(private manageEmployeeService:ManageEmployeeService) { 
    this.selectedEmp.emit(new Employee())
  }
  selectEmp(emp:Employee){
    this.selectedEmp.emit(emp)
  }

  ngOnInit(): void {
    this.empList=this.manageEmployeeService.getEmployees()
  }


}
