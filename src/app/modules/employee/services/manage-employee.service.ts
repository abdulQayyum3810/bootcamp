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

private empDetailUrl: string = "http://localhost/EmpDetailsAPI/api/values/"
getEmpDetail(id:number):Observable<Employee>{

  return this.http.get<Employee>(this.empDetailUrl+id);
}

}
