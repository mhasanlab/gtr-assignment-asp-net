import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly baseURL:string="https://localhost:44361/api/User/"
  constructor(private httpClient:HttpClient) { }

  public login(email:string , password:string)
   {
     const body={
       Email:email,
       Password:password
     }
     return this.httpClient.post(this.baseURL+"Login",body);
    // return this.httpClient.post<ResponseModel>(Constants.BASE_URL+"user/Login",body);
   }
   public register(fullname:string,email:string , password:string)
   {

     const body={
       FullName:fullname,
       Email:email,
       Password:password,
      //  Roles:roles
     }
     return this.httpClient.post(this.baseURL+"RegisterUser",body);
    // return this.httpClient.post<ResponseModel>(Constants.BASE_URL+"user/RegisterUser",body);
   }

}
