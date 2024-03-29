import { ProductDetailsComponent } from './admin/product/product-details/product-details.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import {HttpClientModule} from "@angular/common/http";
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AdminProductListComponent } from './admin/product/product-list/product-list.component';
import { AdminCategoryListComponent } from './admin/category/category-list/category-list.component';
import { CategoryCreateComponent } from './admin/category/category-create/category-create.component';
import { CategoryDetailsComponent } from './admin/category/category-details/category-details.component';
import { ProductCreateComponent } from './admin/product/product-create/product-create.component';
import { NavBarComponentAdmin } from './admin/nav-bar/nav-bar.component';
import { ProductCardComponent } from './product/product-card/product-card.component';
import { CategoryCardComponent } from './category/category-card/category-card.component';
import { ProductListComponent } from './product/product-list/product-list.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { LoginComponent } from './login/login.component';
import { SearchComponent } from './search/search.component';
import { ProductPageComponent } from './product/product-page/product-page.component';


const appRoutes: Routes = [
  {path: "", component: ProductListComponent},
  {path: "search", component: SearchComponent},
  {path: "login", component: LoginComponent},

  {path: "categories", component: CategoryListComponent},
  {path: "products", component: ProductListComponent},
  {path: "products/:id", component: ProductPageComponent},
  // {path: "categories/:id", component: CategoryListComponent},

  {path: "admin/products", component: AdminProductListComponent, data: {navbar: "admin"}},
  {path: "admin/categories", component: AdminCategoryListComponent, data: {navbar: "admin"}},
  {path: "admin/categories/create", component: CategoryCreateComponent, data: {navbar: "admin"}},
  {path: "admin/products/create", component: ProductCreateComponent, data: {navbar: "admin"}},
  {path: "admin/products/:id/edit", component: ProductCreateComponent, data: {navbar: "admin"}},
  {path: "admin/categories/:id/edit", component: CategoryCreateComponent, data: {navbar: "admin"}},
  {path: "admin/products/:id", component: ProductDetailsComponent, data: {navbar: "admin"}},
  {path: "admin/categories/:id", component: CategoryDetailsComponent, data: {navbar: "admin"}},

  {path: "**", component: ProductListComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    NavBarComponentAdmin,
    AdminProductListComponent,
    ProductCreateComponent,
    AdminCategoryListComponent,
    CategoryCreateComponent,
    CategoryDetailsComponent,
    ProductCardComponent,
    ProductListComponent,
    CategoryCardComponent,
    CategoryListComponent,
    LoginComponent,
    SearchComponent,
    ProductPageComponent,
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
