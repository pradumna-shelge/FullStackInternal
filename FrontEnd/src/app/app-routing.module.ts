import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInPageComponent } from './default/sign-in-page/sign-in-page.component';

const routes: Routes = [

  { path: 'signin', component: SignInPageComponent },
{ path: '', pathMatch: 'full', redirectTo: '/signin' },

{
  path: 'admin', 
  loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
