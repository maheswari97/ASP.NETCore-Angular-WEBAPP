import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../app.service';

@Component({
  selector: 'app-edit-hens',
  templateUrl: './edit-hens.component.html',
  styleUrls: ['./edit-hens.component.css']
})
export class EditHensComponent {
Hen_id:any;
Hierarchy_level:any;
Egg_count:any;
Data:any;
Max_Hierarchy:any

  constructor(public App_service: AppService,private _router:Router) {}
  ngOnInit() {

    this.Max_Hierarchy =this.App_service.Hierarchy_level;
  }

  Edit_Hens(){
    this.App_service.Edit_Hens(this.Hen_id,this.Hierarchy_level,this.Egg_count).subscribe(output => {
      this.Data=output;
       alert(this.Data['data']);
 
       this._router.navigateByUrl('');
     })  
  }
}
