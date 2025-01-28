import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddUserComponent } from './Pages/add-user/add-user.component';
import { RouterOutlet } from '@angular/router';
import { AddLoginsComponent } from './Pages/add-logins/add-logins.component';
import { CommonModule } from '@angular/common';

import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { SignupComponent } from './Pages/signup/signup.component';

@NgModule({
  declarations: [
    AppComponent,
    AddUserComponent,
    AddLoginsComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    RouterOutlet,
    CommonModule,
    FormsModule,
    ReactiveFormsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
