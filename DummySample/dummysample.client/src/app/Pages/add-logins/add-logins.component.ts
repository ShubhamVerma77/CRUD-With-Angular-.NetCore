import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { DemoService } from '../../service/demo.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DeleteModel, getbyidModel, UpadteModel,  } from '../../models/demo.model';

@Component({
  selector: 'app-add-logins',
  standalone: false,
  
  templateUrl: './add-logins.component.html',
  styleUrl: './add-logins.component.css'
})
export class AddLoginsComponent implements OnInit {
  form:FormGroup;
  id:any
  name: any;
  description: any;
  type: any;
  constructor(private parms:ActivatedRoute,
    private fb:FormBuilder
  ){
    this.parms.queryParams.subscribe((parms:any)=>{
      this.id= parms.demoID
    })

    this.form = this.fb.group({
      name: ['',Validators.required],
      description: ['',Validators.required],
      type: ['',Validators.required],
    })
    }

    get Controls(){
      return this.form.controls;
    }
  ngOnInit(): void {
   this.getData(this.id);
  }
    service = inject(DemoService)
    router = inject(Router)

    alldata:any;

    getData(demoID:any){
 let api = 'Demo/GetDataById'
 const model = new getbyidModel()
 model.id = demoID
 console.log(model,"ss")
 this.service.postData(api, model).subscribe((res:any)=>{
this.alldata = res.data;
this.name = this.alldata.name;
this.description = this.alldata.description;
this.type = this.alldata.type;
console.log(this.name,"ss")
console.log(this.alldata,"DAta aa Gya Gya Gya Gya Gya Gya Gya Gya bawa")
 })
    }

    deleteitem(data:any){ {
      const model = new DeleteModel()
    model.ID = data;
    console.log(model,"Id")
    console.log(data,"data")
    let api = 'Demo/DeleteData'
    confirm("Are You Sure");
    this.service.postData(api, model).subscribe((res:any)=>{
      if(res.isComplete){
       alert(res.message);
 this.router.navigateByUrl("/list");
      }
      else{
        alert(res.message);
      }
     
     
     
    })
    
      }
    }

    UpdateForm(demoID:any){
      
    let api ='Demo/UpdateData'
    const model = new UpadteModel()
    model.ID = demoID.demoID;
    model.Name = this.Controls['name'].value;
    model.Description = this.Controls['description'].value;
    model.Type = this.Controls['type'].value;
    console.log(model,"model")
    if(this.form.valid){
      this.service.postData(api,model).subscribe((res:any) =>{
        if(res.isComplete){
    alert("Data Update Successfully");
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
