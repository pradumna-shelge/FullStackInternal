import { Component } from '@angular/core';
import { UserAuthService } from '../user-auth.service';
import { signData } from 'src/app/Models/Default';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in-page',
  templateUrl: './sign-in-page.component.html',
  styleUrls: ['./sign-in-page.component.css']
})
export class SignInPageComponent {

 
  constructor(private ser:UserAuthService,private router :Router){}

  signIn(username:string,password:string) {
    this.ser.signIn(username,password).subscribe((d:signData)=>{
      this.ser.setData(d.token,d.role);
    })
    var Role:any = localStorage.getItem('role'); 
  
    if(Role === 'Admin'){
          this.router.navigate(['/admin']);
    }
    else if(Role == 'Devoti'){
      this.router.navigate(['/devoti']);
    }

  }



}
