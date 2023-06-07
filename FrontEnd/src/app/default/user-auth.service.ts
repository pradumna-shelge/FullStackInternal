import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { signData } from '../Models/Default';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {

  private token = ''
  constructor(private http:HttpClient) { }
 

  signIn(username:string,password:string){
    

    const userData = {username,password}

    return this.http.post<signData>('https://localhost:7284/api/UserLogin/signIn',userData);
  }

  setData(token:string,role:string){
    localStorage.setItem('user', token); 
    localStorage.setItem('role', role); 

  }
  removetoken(){
    localStorage.removeItem('user'); 
  }

}
