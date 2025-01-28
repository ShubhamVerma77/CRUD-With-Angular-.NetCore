import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUserComponent } from './Pages/add-user/add-user.component';
import { AddLoginsComponent } from './Pages/add-logins/add-logins.component';
import { SignupComponent } from './Pages/signup/signup.component';

const routes: Routes = [
  {
    path: 'list',
    component: AddUserComponent
  
  },
  {
    path: 'add-logins',
    component: AddLoginsComponent
  },
  {
    path:'',
    component:SignupComponent

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
