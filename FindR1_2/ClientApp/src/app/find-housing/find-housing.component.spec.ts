import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FindHousingComponent } from './find-housing.component';

describe('FindHousingComponent', () => {
  let component: FindHousingComponent;
  let fixture: ComponentFixture<FindHousingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FindHousingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FindHousingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
