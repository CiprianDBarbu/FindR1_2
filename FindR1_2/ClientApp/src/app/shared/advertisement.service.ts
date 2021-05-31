import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Advertisement } from './advertisement.model';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  formData: Advertisement = new Advertisement();
  readonly baseUrl = 'https://localhost:44305/api/Advertisements';

  constructor(private http: HttpClient) { }

  postAdvertisement() {
    return this.http.post(this.baseUrl, this.formData);
  }

  putAdvertisement() {
    return this.http.put(`${this.baseUrl}/${this.formData.advertisement_Id}`, this.formData);
  }

  deleteAdvertisement(id:number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  refreshList(): Observable<Advertisement[]> {

    return this.http.get<Advertisement[]>(this.baseUrl)
      .pipe(
        tap(it => {
          //window.alert('am primit postari ' + it.length);
        })
      );
  }
}
