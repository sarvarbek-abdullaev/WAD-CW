import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-app-property-card',
  templateUrl: './app-property-card.component.html',
  styleUrls: ['./app-property-card.component.css']
})
export class AppPropertyCardComponent {
  @Input() Property : any
}
