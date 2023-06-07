import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { UserData } from 'src/app/Models/Default';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {

userData:UserData = {}as UserData
  constructor(public http:HttpClient){
    this.userget();
  }

userget(){
  var user = localStorage.getItem('userid');
console.log(user);

  this.http.get<UserData>('https://localhost:7284/api/userData/'+user).subscribe(data=>{
    this.userData = data;
  })


}

}
