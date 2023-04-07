import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css']
})
export class CategoryDetailsComponent implements OnInit {

  constructor(private housingService: HousingService, private route: ActivatedRoute, private router: Router) {}

  category: any;
  categoryId!: number;

  deleteCategory(): void {
    this.housingService.deleteCategoryById(this.categoryId).subscribe( {
      next: (data) => { this.category = data; this.router.navigate(["/admin/categories"])} ,
      error: (e) => console.error(e),
    })
  }

  ngOnInit(): void {
    const categoryId = this.route.snapshot.params["id"];
    this.categoryId = categoryId;
    this.housingService.getCategoryById(this.categoryId).subscribe( {
      next: (data) => this.category = data,
      error: (e) => console.error(e),
    })
  }

}
