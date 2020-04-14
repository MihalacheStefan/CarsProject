import { Component, OnInit, Input} from '@angular/core';

@Component({
  selector: 'app-chassis-detail',
  templateUrl: './chassis-detail.component.html',
  styleUrls: ['./chassis-detail.component.css']
})
export class ChassisDetailComponent {
  @Input() chassisDescription: string ;
  @Input() chassisCodeNumber: string ;
  constructor() { }

}
