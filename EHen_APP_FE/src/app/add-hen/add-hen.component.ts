import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../app.service';


@Component({
  selector: 'app-add-hen',
  templateUrl: './add-hen.component.html',
  styleUrls: ['./add-hen.component.css']
})
export class AddHenComponent {
  Hierarchy_level:any;
  Hen_count:any;
  Data:any;
  Max_Hierarchy:number=0;

  constructor(public App_service: AppService,private _router:Router) {}
  ngOnInit() {

    this.Max_Hierarchy =this.App_service.Hierarchy_level;
  }
  Add_Hens(){
    if(this.Hierarchy_level<=this.Max_Hierarchy && this.Hen_count<11)
    {
      this.App_service.Add_Hens(this.Hierarchy_level,this.Hen_count).subscribe(output => {
        this.Data=output;
         alert(this.Data['data']);
   
         this._router.navigateByUrl('');
       })  
    }
    else{
      alert("Hen number must be less than 11 and Hierarchy level must be less than "+(this.Max_Hierarchy+1));
    }
   
  }
}
