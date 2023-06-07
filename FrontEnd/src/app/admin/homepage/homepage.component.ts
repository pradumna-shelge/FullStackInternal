import { Component } from '@angular/core';
import { UserData } from 'src/app/Models/Default';
import { UserDataService } from '../services/user-data.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
userData!:UserData[]


constructor(private ser:UserDataService){
this.getAll()
}

getAll(){
  this.ser.getAll().subscribe(d=>{
    this.userData=d;
    console.log(this.userData);
    
  })
}

delete(id:string){

  this.ser.delete(id);

  this.getAll()
}

}
