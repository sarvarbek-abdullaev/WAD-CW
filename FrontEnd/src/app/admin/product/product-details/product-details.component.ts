import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  constructor(private housingService: HousingService, private route: ActivatedRoute, private router: Router) {}
  productId!: number;
  property: any;


  deleteProduct(): void {
    this.housingService.deleteProductById(this.productId).subscribe( {
      next: (data) => { this.property = data; this.router.navigate(["/admin/products"])} ,
      error: (e) => console.error(e),
    }
    )
  }
  goEdit(): void {
    this.router.navigate(["/admin/products/" + this.productId + "/edit"])
  }

  ngOnInit(): void {
    this.productId = this.route.snapshot.params["id"];
    this.housingService.getProductById(this.productId).subscribe( {
      next: (data) => this.property = data,
      error: (e) => console.error(e),
    }
    )
  }

}
