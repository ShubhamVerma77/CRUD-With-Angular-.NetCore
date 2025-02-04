import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { DemoService } from '../../service/demo.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-add-user',
  standalone: false,
  
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.css'
})
export class AddUserComponent implements OnInit {
data: any;
id:any
Eid: any;
successShow : boolean = false;
ngOnInit(): void {

this.getUser();


// this.onclick(this.demoIDs)
}
service = inject(DemoService)
router = inject(Router)
constructor(private parms:ActivatedRoute){
this.parms.queryParams.subscribe((parms:any)=>{
  this.id = parms.demoID,
    this.Eid = parms.eid
   
})
}

allData: any;
demoIDs:any;
getUser(){
  this.successShow= true;
  let api = 'Demo/GetAllData'
this.service.getData(api).subscribe((res:any)=>{
  this.allData = res.data;
  setTimeout(() => {
  // Check if data exists
      this.successShow = false;
    
  }, 3000); // 3000ms = 3 seconds
  




})
}
onclick(data:any){
 console.log(data,"dvdvu");
  const url = `add-logins?demoID=${data.eid}`

 
 this.router.navigateByUrl(url);
}





}
