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
disabled:boolean=false;
empList:Employee[]=this.manageEmployeeService.getEmployees()
  constructor(private manageEmployeeService:ManageEmployeeService) {

   }

  ngOnInit(): void {
  }
  previousEmp(){
   let a= this.empList.indexOf(this.emp);
    if(a>0){
      if(a===0){
        this.disabled=true
      }
      else{
        this.disabled=false
      }
      this.emp=this.empList[a-1]
    }
  }
  nextEmp(){
    let a= this.empList.indexOf(this.emp);
    if(a>0 && a<this.empList.length-1){
      this.emp=this.empList[a+1]
  }
  
  

}
}
