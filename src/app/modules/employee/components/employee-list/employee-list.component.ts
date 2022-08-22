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
  empList!:any;
  formType:string="Add";
  emp!:Employee
  constructor(private manageEmployeeService:ManageEmployeeService) { 
  }
  selectEmp(emp:Employee){
    this.selectedEmp.emit(emp)
  }

  ngOnInit(): void {
    this.empList=this.manageEmployeeService.getEmployees().subscribe(data=>{this.empList=data})
    this.emp={Id:0,Name:"",Department:""};
  }
  EmpUpdate(emp:Employee){
    this.emp=emp
    this.formType="Update"
    
  }
  EmpDelete(emp:Employee){
   let a:any=this.manageEmployeeService.DelEmployee(emp.Id).subscribe(data=>{a=data});
   this.empList=this.manageEmployeeService.getEmployees().subscribe(data=>{this.empList=data})
    console.log("deleted")
  }

}
