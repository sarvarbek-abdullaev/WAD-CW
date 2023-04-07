import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  @Input() Property : any

  constructor() { }

  ngOnInit() {
    if(this.Property.image == null) {
      this.Property.image = "/assets/1x1.jpg"
    }
  }

}
