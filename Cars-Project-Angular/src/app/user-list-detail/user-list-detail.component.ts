import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-user-list-detail',
  templateUrl: './user-list-detail.component.html',
  styleUrls: ['./user-list-detail.component.css']
})
export class UserListDetailComponent {
  @Input() usersName: string[];
  constructor() { }

}
