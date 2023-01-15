import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../app.service';


@Component({
  selector: 'app-price-index',
  templateUrl: './price-index.component.html',
  styleUrls: ['./price-index.component.css']
})
export class PriceIndexComponent implements OnInit  {



  
  stringJson: any;
  stringObject : any;
  
  constructor(private App_service: AppService,private _router: Router) {}

  ngOnInit() {

    this.App_service.Pindex_get_http() .subscribe(posts => {
     this.stringObject=posts
    });
    
    
  }

  routrEdit(id:number,date:any,price:number){
    this.App_service.Price_id=id;
    this.App_service.Date=date;
    this.App_service.Price=price;
  }


}
