import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class DemoService {

  constructor(private http : HttpClient) { } 
  urlAddress =  environment.API_ENDPOINT;
   postData(route:string,data:any):Observable<any>  {
    return this.http.post(this.createCompleteRoute(route,this.urlAddress),data);
  }
  getData(route:string):Observable<any>{
    return this.http.get(this.createCompleteRoute(route,this.urlAddress));
  }
  private createCompleteRoute(route: string, envAddress: string) {
    return `${envAddress}${route}`;
  }
}
