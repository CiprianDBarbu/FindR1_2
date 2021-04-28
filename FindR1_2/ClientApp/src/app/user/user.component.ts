import { Component, OnInit } from '@angular/core';
import { ApplicationUser } from '../shared/application-user.model';
import { ApplicationUserService } from '../shared/application-user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styles: []
})
export class UserComponent implements OnInit {

  constructor(public service: ApplicationUserService) { }

  userList: ApplicationUser[];

  ngOnInit() {
    this.refreshListNow();
  }

  refreshListNow() {
    this.service.getUsers().subscribe(
      add => this.userList = add
    );
  }

  onDelete(id: string) {
    if (confirm('Are you sure you want to delete this user?')) {
      this.service.deleteUser(id).subscribe(
        res => {
          this.refreshListNow();
        },
        err => {
          console.log(err);
        }
      );
    }
  }

}
