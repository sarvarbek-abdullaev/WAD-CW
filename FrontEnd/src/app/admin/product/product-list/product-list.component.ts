import { Component, OnInit, Input } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class AdminProductListComponent {

  constructor(private housingService: HousingService) {}

  properties: any;

  ngOnInit(): void {
    this.housingService.getAllProducts().subscribe( {
      next: (data) => this.properties = data,
      error: (e) => console.error(e),
    }
    )
  }

}
