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



  chassisDTO: ChassisDTO = {Description: 'T6000', CodeNumber: '114', Cars: []};
  engineDTO: EngineDTO = {Description: 'OPEL-Super', CylindersNumber: 9, Cars: []};
  ngOnInit() {
    //this.chassisService.getChassis('C8501896-21C9-4165-CA00-08D7C2B0A910').subscribe(data => {
    //  this.chassisService.addChassis(this.chassisDTO).subscribe(data => {
    //  this.chassisService.updateChassis(this.chassisDTO).subscribe(data => {
    // this.chassisService.deleteChassis('855E78E2-8B21-4C94-B589-DFBEDD67D594').subscribe(data => {

    //this.engineService.getEngine('34A51B7F-B01D-404C-CF46-08D7C2B0A915').subscribe(data =>{
    //  this.engineService.addEngine(this.engineDTO).subscribe(data =>{
    //   this.engineService.updateEngine(this.engineDTO).subscribe(data =>{
      this.engineService.deleteEngine('7BD94556-3A22-4781-9555-33C0EE381C42').subscribe(data =>{
        console.log('Raspuns', data);
    });
  }



  onSelect(car: CarDTO) {
      if (car === this.selectedCar) {
          // this.selectedCar = null;
      } else {
          this.selectedCar = car;
          console.log(car);
      }
  }

  deleteCar(car: CarDTO) {
    this.carService.deleteCar(car)
          .subscribe();
}
}
