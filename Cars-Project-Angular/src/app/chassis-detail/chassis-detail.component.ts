import { Component, OnInit, Input} from '@angular/core';
import { ChassisDTO } from '../DTOs/DTOs';

@Component({
  selector: 'app-chassis-detail',
  templateUrl: './chassis-detail.component.html',
  styleUrls: ['./chassis-detail.component.css']
})
export class ChassisDetailComponent implements OnInit {
  @Input() chassisDescription: string ;
  @Input() chassisCodeNumber: string ;
  constructor() { }

  ngOnInit() {
  }

}
