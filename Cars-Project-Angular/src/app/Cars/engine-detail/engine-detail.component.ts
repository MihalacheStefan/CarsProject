import { Component, OnInit, Input} from '@angular/core';


@Component({
  selector: 'app-engine-detail',
  templateUrl: './engine-detail.component.html',
  styleUrls: ['./engine-detail.component.css']
})
export class EngineDetailComponent {
  @Input() engineDescription: string;
  @Input() engineCylindersNumber: number;
  constructor() { }

}
