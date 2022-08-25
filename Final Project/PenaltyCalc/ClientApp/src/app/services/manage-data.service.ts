import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { dataModel } from '../models/dataModel';
import { recievedDataModel } from '../models/recievedDataModel';


@Injectable({
  providedIn: 'root'
})
export class ManageDataService {

  constructor(private http:HttpClient) { }

  
  getCountries():Observable<string[]>{
    return this.http.get<string[]>("/api/Penalty/CountriesList")
  }
  getPenalty(data:dataModel):Observable<recievedDataModel>{
    return this.http.post<recievedDataModel>("/api/Penalty/CalculatePenalty",data)
  }

}
