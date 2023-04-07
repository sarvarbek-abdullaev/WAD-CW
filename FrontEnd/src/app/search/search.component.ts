import { Component, OnInit } from '@angular/core';
import { HousingService } from '../services/housing.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  // properties: Array<IProperty>;
  properties: any;

  constructor(private housingService: HousingService) {}

  ngOnInit(): void {
    this.housingService.getAllProducts().subscribe( {
      next: (data) => {
        this.properties = data
        console.log(
          this.properties
        );
      },
      error: (e) => console.error(e),
    })
  }
 }
