import { Component ,Input,OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../app.service';

@Component({
  selector: 'app-new-hierarchy',
  templateUrl: './new-hierarchy.component.html',
  styleUrls: ['./new-hierarchy.component.css']
})
export class NewHierarchyComponent {
  Hierarchy_level:number=0;
  Hen_count:number=0;
  Data:any;

  constructor(private App_service: AppService,private _router:Router) {}

  ngOnInit() {
    this.Hierarchy_level =this.App_service.Hierarchy_level+1;
  }
  Add_Hens(){
    if(this.Hen_count<4)
    {
      this.App_service.Add_Hens_InNewHierarchy(this.Hierarchy_level,this.Hen_count).subscribe(output => {
        this.Data=output;
         alert(this.Data['data']);
   
         this._router.navigateByUrl('');
       }) 
    }
    else{
      alert("Hens number must be between 1 to 10");
      this.Hen_count=0;
    }
         
  }
}
