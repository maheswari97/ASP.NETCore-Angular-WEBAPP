import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../app.service';

@Component({
  selector: 'app-edit-price-index',
  templateUrl: './edit-price-index.component.html',
  styleUrls: ['./edit-price-index.component.css']
})
export class EditPriceIndexComponent {
  constructor(public App_service: AppService,private _router:Router) {}

  Price:number=0;
  Id:number=0;
  data:any
  ngOnInit() {
    this.Price=this.App_service.Price;
    this.Id=this.App_service.Price_id;
  }


  Edit_price(){
    if(this.Price<3 && this.Price>1)
    {
      this.App_service.Edit_price_http(this.Id,this.Price).subscribe(output => {
        this.data=output;
         alert(this.data['data']);
   
         this._router.navigateByUrl('');
       })   
    }
    else{
      alert("Price needs to be less than 3 Euro and greater than 1 euro");
    }
      

  }

}
