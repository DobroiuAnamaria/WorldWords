import { Component, OnInit } from '@angular/core';
import { User } from './user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  selectedUser?: User;

  users: User[] = [];

  user: User = {
    id: 1,
    name: 'Windstorm'
  };
}
