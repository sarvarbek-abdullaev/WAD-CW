import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HousingService } from 'src/app/services/housing.service';
import { FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {

  item: any = { name: '', description: '', price: null, image: '', ProductCategoryId: null }; // initialize to empty object for create
  itemId!: number;
  categories: any;

  constructor(private route: ActivatedRoute, private service: HousingService, private router: Router) {}

  saveItem() {
    if (this.itemId) {
      console.log(this.item);
      this.service.updateProductById(this.itemId, this.item ).subscribe( {
        next: () => {console.log(this.item); this.router.navigate(["/admin/products"]) },
        error: (e) => console.error(e),
      })
    } else {
      this.service.createProduct(this.item).subscribe({
        next: () =>  this.router.navigate(["/admin/products"]) ,
        error: (e) => console.error(e),
      });
    }
  }

  ngOnInit() {
    this.itemId = this.route.snapshot.params['id']; // get item ID from route parameter

    if (this.itemId) {
      this.service.getProductById(this.itemId).subscribe({
        next: (data) => this.item = data,
        error: (e) => console.error(e),
      });
    }

    this.service.getAllCategories().subscribe({
      next: (data) => this.categories = data,
      error: (e) => console.error(e),
    });

  }
}

