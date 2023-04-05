import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppPropertyListComponent } from './app-property-list.component';

describe('AppPropertyListComponent', () => {
  let component: AppPropertyListComponent;
  let fixture: ComponentFixture<AppPropertyListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppPropertyListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppPropertyListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
