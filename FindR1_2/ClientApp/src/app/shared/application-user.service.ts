import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ApplicationUser } from './application-user.model';

@Injectable({
  providedIn: 'root'
})
export class ApplicationUserService {

  readonly baseURL = 'https://localhost:44305/api/ApplicationUsers';


  constructor(private http: HttpClient) { }

  getUsers(): Observable<ApplicationUser[]> {

    return this.http.get<ApplicationUser[]>(this.baseURL)
      .pipe(
        tap(it => {
          window.alert('am primit useri ' + it.length);
      })
      );
  }

  deleteUser(id: string) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
