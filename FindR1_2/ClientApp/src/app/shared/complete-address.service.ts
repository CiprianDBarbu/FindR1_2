import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { CompleteAddress } from './complete-address.model';

@Injectable({
  providedIn: 'root'
})
export class CompleteAddressService {

  formData: CompleteAddress = new CompleteAddress();
  readonly baseURL = 'https://localhost:44305/api/CompleteAddresses';

  constructor(private http: HttpClient) { }

  postCompleteAddresses(){
    return this.http.post(this.baseURL, this.formData);
  }

  putCompleteAddresses() {
    return this.http.put(`${this.baseURL}/${this.formData.completeAddress_Id}`, this.formData);
  }

  deleteCompleteAddresses(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(): Observable<CompleteAddress[]> {
    return this.http.get<CompleteAddress[]>(this.baseURL)
      .pipe(
        tap(it => {
          window.alert(`Received ${it.length} complete addresses!`);
        })
      );
  }
}
