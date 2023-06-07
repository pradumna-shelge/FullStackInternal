import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Image, city } from 'src/app/Models/Default';

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
  getUrl(file:any){
    this.myfile = file.target.files[0];

    const formdata = new FormData();
    formdata.append('file',this.myfile);

    this.http.post<Image>('https://localhost:7284/api/ServiceApi/ImageUrl',formdata).subscribe(d=>{
      this.url = d.url
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

  this.http.post("https://localhost:7284/api/userData",this.userForm.value).subscribe(d=>{
    console.log(  d);
  })



  }
}
