import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppPropertyCardComponent } from './app-property-card.component';

describe('AppPropertyCardComponent', () => {
  let component: AppPropertyCardComponent;
  let fixture: ComponentFixture<AppPropertyCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppPropertyCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppPropertyCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
