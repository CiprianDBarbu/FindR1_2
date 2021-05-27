import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FindRoomatesComponent } from './find-roomates.component';

describe('FindRoomatesComponent', () => {
  let component: FindRoomatesComponent;
  let fixture: ComponentFixture<FindRoomatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FindRoomatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FindRoomatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
