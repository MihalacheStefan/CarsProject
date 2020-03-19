import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';
import { CarDTO, ChassisDTO, EngineDTO, UserDTO } from '../DTOs/DTOs';
import { ChassisService } from '../services/chassis.service';
import { EngineService } from '../services/engine.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  selectedCar: CarDTO;
  private carList: CarDTO[];
  constructor(private carService: CarService) { }

  ngOnInit() {
    this.carService.getCars().subscribe(data => {this.carList = data; console.log(this.carList); });
  }

  onSelect(car: CarDTO) {
      if (car === this.selectedCar) {
          // this.selectedCar = null;
      } else {
          this.selectedCar = car;
      }
  }

  deleteCar(car: CarDTO) {
    this.carService.deleteCar(car.brand)
            .subscribe(x => this.carList = this.carList.filter(c => c !== car) );
  }

}
