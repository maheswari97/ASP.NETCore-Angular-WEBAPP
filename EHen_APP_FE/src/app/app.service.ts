import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';


@Injectable({
    providedIn: 'root'
  })

export class AppService {

Data:any;
Hierarchy_level:number=0;

Price_id:number=0
Date:any;
Price:number=0
BaseURL:String='https://localhost:7225';

    constructor(
        private http: HttpClient
      ) {}

HenDetails_gethttp(){
    return this.http.get(this.BaseURL+'/api/EHen_app/Hens_details');
}

Pindex_get_http(){
  return this.http.get(this.BaseURL+'/api/EHen_app/Price_index');
}

Edit_price_http(id:number,price:number){
  return this.http.post(this.BaseURL+'/api/EHen_App/Edit_Pindex' , {id:id,price:price},) ;
}

   Get_HenDetails_With_GiveDate(Date:any){
    return this.http.post(this.BaseURL+'/api/EHen_App/Get_Hen_data_WithGivenDate' , {Data:Date},) ;
   } 

Add_Hens_InNewHierarchy(Hierarchy_Level:number,Hen_Count:number){
  return this.http.post(this.BaseURL+'/api/EHen_App/Add_Hen_In_NewHierarchy' , {Hierarchy_level:Hierarchy_Level,Hens_count:Hen_Count},) ;
}
Edit_Hens(Hen_id:any,Hierarchy_level:any,Egg_count:any){
  return this.http.post(this.BaseURL+'/api/EHen_App/Edit_Hen' , {Hen_Id:Hen_id,Hierarchy_level:Hierarchy_level,Egg_num:Egg_count},) ;
}
Add_Hens(Hierarchy_Level:number,Hen_Count:number){
  return this.http.post(this.BaseURL+'/api/EHen_App/Add_Hen' , {Hierarchy_level:Hierarchy_Level,Hens_count:Hen_Count},) ;
}

}