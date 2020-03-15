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
  constructor(private carService: CarService,
              private userService: UserService) { }

//  chassisDTO: ChassisDTO = {Description: 'T6000', CodeNumber: '114', Brands: ['Carapace']};
    carDTO: CarDTO = {brand: 'BMW', chassisDescription: 'BMW-22', chassisCodeNumber: '22',
                      engineDescription: 'BMW-10', engineCylindersNumber: 10, usersName: ['Ionel']};
//  engineDTO: EngineDTO = {Description: 'Motorola', CylindersNumber: 80, Brands: ['Carapace']};
   // userDTO: UserDTO = {Name: 'Ionel', Brands: ['Bugatti']};

  ngOnInit() {
    this.carService.getCars().subscribe(data => {this.carList = data; console.log(this.carList); });

    this.carService.updateCar(this.carDTO).subscribe(data => console.log('Raspuns', data));
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
