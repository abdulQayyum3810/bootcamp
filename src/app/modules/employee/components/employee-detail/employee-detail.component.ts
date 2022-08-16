import { Component, OnInit,Input } from '@angular/core';
import { Employee } from '../../models/EmployeeDetail';
import { ManageEmployeeService } from '../../services/manage-employee.service';
@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {


@Input() empIndex!:number;
@Input() available!:boolean;
disabled:boolean=false;
emp:any=this.manageEmployeeService.getEmpDetail(this.empIndex).subscribe(data=>{this.emp=data})
empList:any=this.manageEmployeeService.getEmployees().subscribe(data=>{this.empList=data})
  constructor(private manageEmployeeService:ManageEmployeeService) {

   }

  ngOnInit(): void {
  }
  previousEmp(){
   let a= this.emp.Id;
    if(a>0){
      this.emp=this.manageEmployeeService.getEmpDetail(1).subscribe(data=>{this.emp=data})
      
    }
    console.log("prev clicked",this.emp)
  }
  nextEmp(){
    let a= this.empList.indexOf(this.emp);
    if(a>0 && a<this.empList.length-1){
      this.emp=this.empList[a+1]
      console.log("next clicked",this.emp)
  }
  
  

}
}
