import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserData } from 'src/app/Models/Default';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  constructor(private http:HttpClient) { }


  getAll(){
    return this.http.get<UserData[]>('https://localhost:7284/api/userData')
  }

  delete(id:string){
    console.log(id);
    
    return this.http.delete('https://localhost:7284/api/userData/'+id)
  }
}
