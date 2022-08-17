import { Component, OnInit,Input } from '@angular/core';
import { Employee } from '../../models/EmployeeDetail';
import { ManageEmployeeService } from '../../services/manage-employee.service';
@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {


@Input() emp!:any;
@Input() available!:boolean;
disabled:boolean=false;


  constructor(private manageEmployeeService:ManageEmployeeService) {
    
   }
  empList:any=this.manageEmployeeService.getEmployees().subscribe(data=>{this.empList=data})
  ngOnInit(): void {
  }
  previousEmp(){
   let a= this.getIndex();
    if(a>0){

      this.emp=this.manageEmployeeService.getEmpDetail(this.empList[a-1].Id).subscribe(data=>{this.emp=data})
      
    }
    console.log("prev clicked2",this.emp)
  }
  nextEmp(){
    let a= this.getIndex();
    if(a<this.empList.length){

      this.emp=this.manageEmployeeService.getEmpDetail(this.empList[a+1].Id).subscribe(data=>{this.emp=data})
      
    }
    console.log("next clicked",this.emp)
  
    
  }
  getIndex(){ 
    let a=0;
   for(let i=0;i<this.empList.length;i++){
    if (this.empList[i].Id===this.emp.Id)
      a=i;
   }
return a;
    }
}
