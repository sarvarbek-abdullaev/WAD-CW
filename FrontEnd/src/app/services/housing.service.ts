import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor(private http:HttpClient) {

  }
  mainUrl : any = "http://localhost:13413/";

  getAllProducts() {
    return this.http.get(this.mainUrl + "api/Product" )
  }

  getAllCategories() {
    return this.http.get(this.mainUrl + "api/Category" )
  }

  getProductById(id :number) {
    return this.http.get(this.mainUrl + "api/Product/" + id )
  }

  getCategoryById(id :number) {
    return this.http.get(this.mainUrl + "api/Category/" + id )
  }

  deleteCategoryById(id :number) {
    return this.http.delete(this.mainUrl + "api/Category/" + id )
  }

  deleteProductById(id :number) {
    return this.http.delete(this.mainUrl + "api/Product/" + id )
  }

  updateProductById(id :number, product: any) {
    return this.http.put(this.mainUrl + "api/Product/" + id, {
      "id": id,
      "name": product.name,
      "description": product.description,
      "price": product.price,
      "ProductCategoryId": product.ProductCategory.Id
    })
  }

  updateCategoryById(id :number, category: any) {
    return this.http.put(this.mainUrl + "api/Category/" + id, {
      "id": id,
      "name": category.name,
      "image": category.image,
      "description": category.description
    })
  }

  createProduct(product: any) {
    return this.http.post(this.mainUrl + "api/Product/", {
      "name": product.name,
      "description": product.description,
      "price": product.price,
      "ProductCategoryId": product.ProductCategoryId
    })
  }

  createCategory(category: any) {
    return this.http.post(this.mainUrl + "api/Category/", {
      "name": category.name,
      "image": category.image,
      "description": category.description
    })
  }

}
