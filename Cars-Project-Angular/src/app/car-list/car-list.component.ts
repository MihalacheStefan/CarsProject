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
  private carList;
  private list = [ {Brand: 'Skoda', Chassis: {Description: 'Skoda-Description', CodeNumber: '1234'},
                   Engine: {Description: 'EngineDescription', CylindersNr: 3 }},
                   {Brand: 'Opel', Chassis: {Description: 'Opel-Description', CodeNumber: '1234'},
                   Engine: {Description: 'EngineDescription', CylindersNr: 5 }}];
  constructor(private carService: CarService,
              private chassisService: ChassisService,
              private engineService: EngineService,
              private userService: UserService) { }



//  chassisDTO: ChassisDTO = {Description: 'T6000', CodeNumber: '114', Brands: ['Carapace']};
 
    carDTO: CarDTO = {Brand: 'Bugatti', ChassisDescription: 'Extreme', ChassisCodeNumber: '500',
                      EngineDescription: 'Bugatti-Engine', EngineCylindersNumber: 13, UsersName: ['Ionel']};

//  engineDTO: EngineDTO = {Description: 'Motorola', CylindersNumber: 80, Brands: ['Carapace']};
  
    userDTO: UserDTO = {Name: 'Ionel', Brands: ['Carapace']};

  ngOnInit() {
      // this.carService.updateCar(this.carDTO).subscribe(data =>{
      //      console.log('Raspuns', data);
      // });
      //this.carService.getCars().subscribe(data => console.log('Raspuns', data));
     // this.chassisService.updateChassis(this.chassisDTO).subscribe(data => console.log('Raspuns', data));
    //  this.userService.updateUser(this.userDTO).subscribe(data => console.log('Raspuns', data));
    this.userService.deleteUser('F54E4252-C645-451C-98AD-1936F33271BC').subscribe(data => console.log('Raspuns', data));
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
