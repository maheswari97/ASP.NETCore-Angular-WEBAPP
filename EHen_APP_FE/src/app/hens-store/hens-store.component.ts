import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';

@Component({
  selector: 'app-hens-store',
  templateUrl: './hens-store.component.html',
  styleUrls: ['./hens-store.component.css']
})
export class HensStoreComponent {

  Hens_object:any;
  Pindex_list:any;
  SelectedDate:any;

  constructor(private App_service: AppService) {}

  ngOnInit() {

    this.App_service.HenDetails_gethttp()         
    .subscribe(posts => {
     this.Hens_object=posts
     console.log(this.Hens_object[0]['hierarchy_level']);
     this.App_service.Hierarchy_level=this.Hens_object[0]['hierarchy_level'];
    });


    this.App_service.Pindex_get_http() .subscribe(posts => {
      this.Pindex_list=posts;
      this.SelectedDate=this.Pindex_list[0]['date'];
     });
  }

  onChange_Date(){
    this.App_service.Get_HenDetails_With_GiveDate(this.SelectedDate).subscribe(output => {
      this.Hens_object=output
      console.log(this.Hens_object[0]['per_EggPrice']);
      this.App_service.Hierarchy_level=this.Hens_object[0]['hierarchy_level'];
     })      
  }

}
