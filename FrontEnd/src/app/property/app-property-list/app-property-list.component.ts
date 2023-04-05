import { HousingService } from './../../services/housing.service';
import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { IProperty } from '../IProperty.interface';

@Component({
  selector: 'app-app-property-list',
  templateUrl: './app-property-list.component.html',
  styleUrls: ['./app-property-list.component.css']
})
export class AppPropertyListComponent implements OnInit  {
  // properties: Array<IProperty>;
  properties: any;

  constructor(private housingService: HousingService) {}

  ngOnInit(): void {
    this.housingService.getAllProperties().subscribe( {
      next: (data) => this.properties = data,
      error: (e) => console.error(e),
    }
    )
  }

}
