import { Component, OnInit } from '@angular/core';
import { ApplicationUser } from '../shared/application-user.model';
import { ApplicationUserService } from '../shared/application-user.service';

@Component({
  selector: 'app-find-roomates',
  templateUrl: './find-roomates.component.html',
  styleUrls: ['./find-roomates.component.css']
})
export class FindRoomatesComponent implements OnInit {

  usersList: ApplicationUser[];
  actualUserDisplayed: ApplicationUser;
  actualIndex: number;

  constructor(public aus: ApplicationUserService) { }

  ngOnInit() {
    this.getusers();
    //this.actualUserDisplayed = this.usersList[0];
    this.actualIndex = 0;
  }

  getusers() {
    this.aus.getUsers().subscribe(
      add => { this.usersList = add; this.actualUserDisplayed = add[0]; }
    );
  }

  nextUser() {
    if (this.actualIndex < this.usersList.length) {
      this.actualIndex += 1;
    }
    else {
      this.actualIndex = 0;
    }
    this.actualUserDisplayed = this.usersList[this.actualIndex];
  }

  addFriend() {

  }
}
