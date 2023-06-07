import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { devoties } from 'src/app/Models/Default';

@Component({
  selector: 'app-donation',
  templateUrl: './donation.component.html',
  styleUrls: ['./donation.component.css']
})
export class DonationComponent {

donation!:devoties[]

  constructor(private http:HttpClient){
    this.getDonation();
  }

  getDonation(){
    this.http.get<devoties[]>('https://localhost:7284/api/Devoties',).subscribe(data=>{
this.donation = data
    })
  }
}
