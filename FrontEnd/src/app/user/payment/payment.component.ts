import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { OTP } from 'src/app/Models/Default';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
   months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
   date = new Date().getFullYear()
   number = [0,1,2,3,4,5,6,7,8,9,10,11,12]

constructor(private http:HttpClient){}

otp=''

sendOtp(){
  var id = localStorage.getItem('userid');

  this.http.get<OTP>('https://localhost:7284/api/DonationApi/'+id).subscribe(data =>{
this.otp = data.otp;
console.log(this.otp);

  })
} 



   payment(otp:string, year: string, month: string, pay: string){
if(this.otp === otp){


    var id = localStorage.getItem('userid');
const data = {userID: id ,month: Number( month), amount: Number( pay), year:Number( year)}

console.log(data);

    this.http.post('https://localhost:7284/api/DonationApi',data).subscribe(response=>{
      alert("Payment Successful!")
      console.log(response);
      
     
    })
  }
  else{
    alert("Payment Failed otp is wrong" )
  }
   }
}
