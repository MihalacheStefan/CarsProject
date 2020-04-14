import { Component, Input } from '@angular/core';
import { AdComponentInterface } from '../ad-component.interface';

@Component({
  selector: 'app-chassis-ad',
  templateUrl: './chassis-ad.component.html',
  styleUrls: ['./chassis-ad.component.css']
})
export class ChassisAdComponent implements AdComponentInterface {
  @Input() data: any;

}
