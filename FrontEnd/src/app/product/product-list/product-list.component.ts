import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

 // properties: Array<IProperty>;
 properties: any;

 constructor(private housingService: HousingService) {}

 ngOnInit(): void {
   this.housingService.getAllProducts().subscribe( {
     next: (data) => this.properties = data,
     error: (e) => console.error(e),
   }
   )
 }

}
