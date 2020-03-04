import { Component, OnInit } from '@angular/core';
import { CarService } from '../car.service';
import { CarDTO } from '../CarDTO';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  selectedCar: CarDTO;
  private carList;
  private list = [ {Brand: 'Skoda', Chassis: {Description: 'Skoda-Description', CodeNumber: '1234'},
                   Engine: {Description: 'EngineDescription', CylindersNr: 3 }},
                   {Brand: 'Opel', Chassis: {Description: 'Opel-Description', CodeNumber: '1234'},
                   Engine: {Description: 'EngineDescription', CylindersNr: 5 }}];
  constructor(private carService: CarService) { }

  ngOnInit() {
    this.carService.getCars().subscribe(data => this.carList = data );
  }
  onSelect(car: CarDTO) {
      if (car === this.selectedCar) {
          // this.selectedCar = null;
      } else {
          this.selectedCar = car;
          console.log(car);
      }
  }
}
