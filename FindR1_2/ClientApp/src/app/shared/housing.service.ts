import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Housing } from './housing.model';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  formData: Housing = new Housing();
  readonly baseURL = 'https://localhost:44305/api/Housings';

  constructor(private http: HttpClient) { }

  postHousing() {
    return this.http.post(this.baseURL, this.formData);
  }

  putHousing() {
    return this.http.put(`${this.baseURL}/${this.formData.housing_Id}`, this.formData);
  }

  deleteHousing(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(): Observable<Housing[]> {
    return this.http.get<Housing[]>(this.baseURL)
      .pipe(
        tap(it => {
          window.alert(`Received ${it.length} housings!`);
        })
      );
  }
}
