import { Component, OnInit,Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../../models/EmployeeDetail';
import { ManageEmployeeService } from '../../services/manage-employee.service';
@Component({
  selector: 'app-emp-form',
  templateUrl: './emp-form.component.html',
  styleUrls: ['./emp-form.component.css']
})
export class EmpFormComponent implements OnInit {
  @Input() formType!:string;
  @Input() name!:string;
  @Input() dept!:string;
  @Input() emp!:Employee;
empForm!:FormGroup;


  constructor(private fb:FormBuilder, private manageEmployeeService:ManageEmployeeService) { }

  ngOnInit(): void {
    this.empForm = this.fb.group({
      empName : ["", [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(150)
      ]],
      empDept : ["", [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(150)
      ]]
    })
  }
  
async submit(){
  const formValues=this.empForm.value;
  if (this.formType=="Update"&& this.empForm.valid){
    this.emp.Name=formValues.empName
    this.emp.Department=formValues.empDept
    this.manageEmployeeService.UpdateEmp(this.emp).subscribe(data=>console.log(data))
    

  }
  else if(this.formType==="Add"){
    console.log("Added")
  }
}

}
