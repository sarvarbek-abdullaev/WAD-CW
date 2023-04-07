import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

 // properties: Array<IProperty>;
 properties: any;

 constructor(private housingService: HousingService) {}

 ngOnInit(): void {
   this.housingService.getAllCategories().subscribe( {
     next: (data) => this.properties = data,
     error: (e) => console.error(e),
   }
   )
 }

}
