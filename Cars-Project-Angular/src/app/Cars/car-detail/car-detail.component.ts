import { Component, OnInit, Input } from '@angular/core';
import { CarDTO } from '../../DTOs/DTOs';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent {
  @Input() car: CarDTO;
  clickedChassis = true;
  clickedEngine = true;
  clickedUsers = true;

  constructor() { }

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

  clickUsers() {
    if(this.clickedUsers){
        this.clickedUsers = false;
    } else {
        this.clickedUsers = true;
    }
  }

}
