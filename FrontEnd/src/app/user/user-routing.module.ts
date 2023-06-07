import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { HomepageComponent } from './homepage/homepage.component';
import { PaymentComponent } from './payment/payment.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [

  { path: '', component: NavbarComponent,

children:[
  { path: 'home', component: HomepageComponent },
  { path: 'pay', component: PaymentComponent },
  { path: 'profile', component: ProfileComponent },
  { path: '', pathMatch: 'full', redirectTo: '/devoti/home' },
]
},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
