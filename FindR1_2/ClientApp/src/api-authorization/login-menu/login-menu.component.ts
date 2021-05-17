import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from '../authorize.service';
import { Observable } from 'rxjs';
import { find, map, tap } from 'rxjs/operators';
import { ApplicationUserService } from '../../app/shared/application-user.service';
import { ApplicationUser } from '../../app/shared/application-user.model';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;
  public firstName: Observable<string>;
  public profilePicture: Observable<HTMLImageElement>;
  private usersList: ApplicationUser[];

  constructor(private authorizeService: AuthorizeService,private usersService: ApplicationUserService) { }

  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.firstName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.profilePicture = this.authorizeService.getUser().pipe(map(u => u && u.profilePicture));
    }
}
