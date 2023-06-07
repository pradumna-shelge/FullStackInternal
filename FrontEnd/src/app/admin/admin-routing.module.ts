import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { HomepageComponent } from './homepage/homepage.component';
import { CreateUserComponent } from './create-user/create-user.component';

const routes: Routes = [

  { path: '', component: NavbarComponent,
children:[
  { path: '', component: HomepageComponent },
  { path: 'create', component: CreateUserComponent },
  // { path: '', pathMatch: 'full', redirectTo: '/admin/home' },

]
},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
