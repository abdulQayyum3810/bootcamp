import { Injectable } from '@angular/core';
import { Employee } from '../models/EmployeeDetail';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ManageEmployeeService {

  constructor(private http: HttpClient) { }
  private url: string = "http://localhost/EmpAPI/api/values"
getEmployees():Observable<object[]>{
  return this.http.get<object[]>(this.url);
}

}
