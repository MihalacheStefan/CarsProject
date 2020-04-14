import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChassisAdComponent } from './chassis-ad.component';

describe('ChassisAdComponent', () => {
  let component: ChassisAdComponent;
  let fixture: ComponentFixture<ChassisAdComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChassisAdComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChassisAdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
