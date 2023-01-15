import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { PriceIndexComponent } from './price-index/price-index.component';
import { HensStoreComponent } from './hens-store/hens-store.component';
import { NewHierarchyComponent } from './new-hierarchy/new-hierarchy.component';
import { EditHensComponent } from './edit-hens/edit-hens.component';
import { AddHenComponent } from './add-hen/add-hen.component';
import { EditPriceIndexComponent } from './edit-price-index/edit-price-index.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
     FormsModule,
    RouterModule.forRoot([
      { path: '', component: HensStoreComponent },
      { path: 'New_Hierarchy', component: NewHierarchyComponent },
      { path: 'Add_Hen', component: AddHenComponent },
      { path: 'Edit_Hen', component: EditHensComponent },
      { path: 'Price', component: PriceIndexComponent },
      { path: 'Edit_price_index', component: EditPriceIndexComponent },
    ])
  ],
  declarations: [
    AppComponent,
    TopBarComponent,
    PriceIndexComponent,
    HensStoreComponent,
    NewHierarchyComponent,
    EditHensComponent,
    AddHenComponent,
    EditPriceIndexComponent
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
