import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Image, UserData, city } from 'src/app/Models/Default';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent {
  userForm!: FormGroup;
  states!:city[];
  cityData!:city[];
  constructor(private formBuilder: FormBuilder, private http:HttpClient) { }

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      photoURL: [''],
      flatNumber: [''],
      addressLine: [''],
      stateId: ['', Validators.required],
      cityId: ['', Validators.required],
      pinCode: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      initiationDate: ['', Validators.required]
    });



    this.http.get<city[]>('https://localhost:7284/api/cityies/state').subscribe(d=>{
      this.states = d;
    })
  }

  myfile!:File
  url=''
    urlmake(file:any){
  
      this.myfile = file.target.files[0];
  
      const formdata = new FormData();
      formdata.append('file',this.myfile);
  
      this.http.post<Image>("https://localhost:7284/api/cityies/ImageUrl",formdata).subscribe((data:Image) =>{
          this.url = data.url;
          console.log(this.url);
          
      })
    }
  

  chagestate(){

    var id = this.userForm.get('stateId')?.value;
  
    console.log(id);
  
    
    this.http.get<city[]>('https://localhost:7284/api/cityies/'+ Number(id)).subscribe(d=>{
      this.cityData = d;
    })
  }


  submit(){
    var ob:UserData = {
      firstName: this.userForm.get('firstName')?.value,
      middleName: this.userForm.get('middleName')?.value,
      lastName: this.userForm.get('lastName')?.value,
      cityId: this.userForm.get('cityId')?.value,
      stateId: this.userForm.get('stateId')?.value,
      addressLine:this.userForm.get('addressLine')?.value,
      initiationDate:this.userForm.get('initiationDate')?.value,
      pinCode:this.userForm.get('pinCode')?.value,
      email:this.userForm.get('email')?.value,
      userId:'',
      flatNumber:this.userForm.get('flatNumber')?.value,
      photoURL:this.url
    }
  this.http.post("https://localhost:7284/api/userData",ob).subscribe(d=>{
    console.log(d);
  })



  }
}
