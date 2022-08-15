import { Injectable } from '@angular/core';
import { Employee } from '../models/EmployeeDetail';

@Injectable({
  providedIn: 'root'
})
export class ManageEmployeeService {
employeesList: Employee[]=[{id:1,name:"Abdullah",Department:"Enginnering"},
{id:2,name:"Imran",Department:"Development"},
{id:3,name:"Khuram",Department:"Quality Assurance"},
{id:3,name:"Ubaidullah",Department:"Computer Science"},
{id:4,name:"Amjad",Department:"Artificial Intelligence"},
{id:5,name:"Furqan",Department:"Quality Assurance"}

]
  constructor() { }
getEmployees():Employee[]{
  return this.employeesList
}

}
