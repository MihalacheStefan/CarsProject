import { Component, OnInit, Input} from '@angular/core';
import { EngineDTO } from '../DTOs/DTOs';

@Component({
  selector: 'app-engine-detail',
  templateUrl: './engine-detail.component.html',
  styleUrls: ['./engine-detail.component.css']
})
export class EngineDetailComponent implements OnInit {
  @Input() engineDescription: string;
  @Input() engineCylindersNumber: number;
  constructor() { }

  ngOnInit() {
  }

}
