import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  constructor(private housingService: HousingService, private route: ActivatedRoute, private router: Router) { }

  product: any;
  productId!: number;

  ngOnInit(): void {
    this.productId = this.route.snapshot.params["id"];
    this.housingService.getProductById(this.productId).subscribe( {
      next: (data) => { this.product = data;
        if(this.product.image == null) this.product.image = '/assets/1x1.jpg'
      },
      error: (e) => console.error(e),
    })
  }

}
