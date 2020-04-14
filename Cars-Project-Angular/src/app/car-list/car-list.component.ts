import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';
import { CarDTO } from '../DTOs/DTOs';


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
      if (car !== this.selectedCar) {
          this.selectedCar = car;
      }
  }

  deleteCar(car: CarDTO) {
    this.carService.deleteCar(car.brand)
            .subscribe(x => this.carList = this.carList.filter(c => c !== car) );
  }

}
