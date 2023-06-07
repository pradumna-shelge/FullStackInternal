import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { payments } from 'src/app/Models/Default';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
constructor(private http:HttpClient){
this.getPayemts();
}
payments!:payments[]
months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];


getPayemts(){
  var id = localStorage.getItem('userid');
  console.log(id);
  
  this.http.get<payments[]>('https://localhost:7284/api/DonationApi/getpayment/'+id).subscribe(data=>{
    this.payments = data;
   
    console.log(data);
    
  });
}
}
