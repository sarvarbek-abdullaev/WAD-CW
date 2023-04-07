import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class AdminCategoryListComponent implements OnInit {

  constructor(private housingService: HousingService) {}

  categories: any;

  ngOnInit(): void {
    this.housingService.getAllCategories().subscribe( {
      next: (data) => this.categories = data,
      error: (e) => console.error(e),
    }
    )
  }

}
