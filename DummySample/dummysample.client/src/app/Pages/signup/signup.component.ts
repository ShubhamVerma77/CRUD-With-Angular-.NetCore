import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InsertDataParamsmodel } from '../../models/demo.model';
import { DemoService } from '../../service/demo.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  standalone: false,
  
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {

loginform : FormGroup;
constructor(private formBuilder: FormBuilder,
  private services:DemoService,
  private router:Router
) { 
this.loginform = formBuilder.group({
  name: ['',Validators.required],
  description:['',Validators.required],
  type:['',Validators.required]


})

}

get Controls(){
  return this.loginform.controls;
}
onSubmit() {

let api = 'Demo/SaveData'
const model = new InsertDataParamsmodel()
model.Name = this.Controls['name'].value;
model.Description = this.Controls['description'].value;
model.Type = this.Controls['type'].value;
if(this.loginform.valid){
  this.services.postData(api,model).subscribe((res:any) =>{
    if(res.isComplete){
alert("Data Saved Successfully");
console.log(res);
this.router.navigate(['/list']);
    }
    else{
      alert("Error Occured")
    }
  })
}
else{
  alert("Please fill all the fields");
}

  }
}
