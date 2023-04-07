import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
export class CategoryCreateComponent implements OnInit {
  item: any = { name: '', description: '' }; // initialize to empty object for create
  itemId!: number;

  constructor(private route: ActivatedRoute, private service: HousingService, private router: Router) {}

  saveItem() {
    if (this.itemId) {
      this.service.updateCategoryById(this.itemId, this.item ).subscribe( {
        next: () => this.router.navigate(["/admin/categories"]),
        error: (e) => console.error(e),
      })
    } else {
      this.service.createCategory(this.item).subscribe({
        next: () =>  this.router.navigate(["/admin/categories"]) ,
        error: (e) => console.error(e),
      });
    }
  }

  ngOnInit() {
    const itemId = this.route.snapshot.params['id']; // get item ID from route parameter
    this.itemId = itemId;

    if (this.itemId) {
      this.service.getCategoryById(this.itemId).subscribe({
        next: (data) => this.item = data,
        error: (e) => console.error(e),
      });
    }
  }

}
