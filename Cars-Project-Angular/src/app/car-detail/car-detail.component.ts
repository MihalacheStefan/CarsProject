import { Component, OnInit, Input } from '@angular/core';
import { CarService } from '../services/car.service';
import { CarDTO } from '../DTOs/DTOs';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {
  @Input() car: CarDTO;
  clickedChassis = true;
  clickedEngine = true;
  constructor(
    private carService: CarService
  ) { }

  ngOnInit() {
  }
  clickChassis() {
    if(this.clickedChassis) {
        this.clickedChassis = false;
    } else {
        this.clickedChassis = true;
    }
  }
  clickEngine() {
    if(this.clickedEngine){
        this.clickedEngine = false;
    } else {
        this.clickedEngine = true;
    }
  }
}
