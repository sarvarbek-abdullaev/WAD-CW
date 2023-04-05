import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import {HttpClientModule} from "@angular/common/http";

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { ProductComponent } from './product/product.component';
import { AppPropertyCardComponent } from './property/app-property-card/app-property-card.component';
import { AppPropertyListComponent } from './property/app-property-list/app-property-list.component';
import { PropertyDetailComponent } from './property-detail/property-detail.component';
import { AddPropertyComponent } from './property/add-property/add-property.component';


const appRoutes: Routes = [
  {path: "", component: AppPropertyListComponent},
  {path: "rent", component: AppPropertyListComponent},
  {path: "property-detail/:id", component: PropertyDetailComponent},
  {path: "add-property", component: AddPropertyComponent},
  {path: "**", component: AppPropertyListComponent}
]


@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ProductComponent,
    AppPropertyCardComponent,
    PropertyDetailComponent,
    AppPropertyListComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
