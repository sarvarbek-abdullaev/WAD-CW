import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.css']
})
export class CategoryCardComponent implements OnInit {
  @Input() Property : any
  constructor() { }

  ngOnInit() {
    if(this.Property.image == null) {
      this.Property.image = "/assets/1x1.jpg"
    }
  }

}
