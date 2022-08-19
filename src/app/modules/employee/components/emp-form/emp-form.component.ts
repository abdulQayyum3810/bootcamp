import { Component, OnInit,Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ManageEmployeeService } from '../../services/manage-employee.service';
@Component({
  selector: 'app-emp-form',
  templateUrl: './emp-form.component.html',
  styleUrls: ['./emp-form.component.css']
})
export class EmpFormComponent implements OnInit {
empForm!:FormGroup;
formType!:string;
  constructor(private fb:FormBuilder, private manageEmployeeService:ManageEmployeeService) { }

  ngOnInit(): void {

    this.empForm = this.fb.group({
      empName : ['', [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(150)
      ]],
      empDept : ['', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(150)
      ]]
    })
  }
async submit(){
  const formValues=this.empForm.value;
  if (this.formType=="Update"){
    console.log("Updated")
  }
  else if(this.formType==="Add"){
    console.log("Added")
  }
}

}
