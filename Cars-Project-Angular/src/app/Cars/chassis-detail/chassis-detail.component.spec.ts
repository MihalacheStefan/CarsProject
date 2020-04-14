import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChassisDetailComponent } from './chassis-detail.component';

describe('ChassisDetailComponent', () => {
  let component: ChassisDetailComponent;
  let fixture: ComponentFixture<ChassisDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChassisDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChassisDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
