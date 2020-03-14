import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';
import { CarDTO, ChassisDTO, EngineDTO } from '../DTOs/DTOs';
import { ChassisService } from '../services/chassis.service';
import { EngineService } from '../services/engine.service';

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
  constructor(private carService: CarService,
              private chassisService: ChassisService,
              private engineService: EngineService) { }



  chassisDTO: ChassisDTO = {Description: 'T6000', CodeNumber: '114', Brands: ['Carapace']};
 
  carDTO: CarDTO = {Brand: 'Bugatti', ChassisDescription: 'Extreme', ChassisCodeNumber: '500',
                    EngineDescription: 'Bugatti-Engine', EngineCylindersNumber: 13};

  engineDTO: EngineDTO = {Description: 'Motorola', CylindersNumber: 80, Brands: ['Carapace']};
  
  ngOnInit() {

      // this.carService.getCar('9F749DDA-2644-4CD7-57C2-08D7C7979A6D').subscribe(data => {
      //     this.carDTO.Chassis.Cars.push(data);
      //     console.log('carDTO modified: ', this.carDTO);
      //     // this.carService.updateCar(this.carDTO).subscribe(data =>{
      //     //     console.log('Raspuns', data);
      //     // });
      // });
      // this.carService.updateCar(this.carDTO).subscribe(data =>{
      //      console.log('Raspuns', data);
      // });
      //this.carService.getCars().subscribe(data => console.log('Raspuns', data));
      this.chassisService.updateChassis(this.chassisDTO).subscribe(data => console.log('Raspuns', data));
  }



  onSelect(car: CarDTO) {
      if (car === this.selectedCar) {
          // this.selectedCar = null;
      } else {
          this.selectedCar = car;
          console.log(car);
      }
  }

  // deleteCar(car: CarDTO) {
  //   this.carService.deleteCar(car)
  //         .subscribe();
  // }

}
