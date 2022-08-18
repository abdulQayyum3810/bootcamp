import { Injectable } from '@angular/core';
import { Employee } from '../models/EmployeeDetail';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ManageEmployeeService {

  constructor(private http: HttpClient) { }
  private employeesUrl: string = "http://localhost/EmpAPI/api/values"
getEmployees():Observable<object[]>{
  return this.http.get<object[]>(this.employeesUrl);
}

private empDetailUrl: string = "http://localhost/OneEmpOpperations/EmployeeDetails/"
getEmpDetail(id:number):Observable<Employee>{

  return this.http.get<Employee>(this.empDetailUrl+id);
}

private empDeleteUrl:string = "http://localhost/OneEmpOpperations//DelEmp/"
DelEmployee(id:number):Observable<string>{

  return this.http.get<string>(this.empDeleteUrl+id);
}

private empUpdateUrl: string = "http://localhost/OneEmpOpperations/UpdateEmployee"
UpdateEmp(employee:Employee):Observable<string>{

  return this.http.post<string>(this.empUpdateUrl, employee)
  
}



}
