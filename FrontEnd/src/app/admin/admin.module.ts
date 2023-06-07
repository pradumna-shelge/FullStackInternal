import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { HomepageComponent } from './homepage/homepage.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { DonationComponent } from './donation/donation.component';


@NgModule({
  declarations: [
    HomepageComponent,
    NavbarComponent,
    CreateUserComponent,
    DonationComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ReactiveFormsModule
  
  ]
})
export class AdminModule { }
