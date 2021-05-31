import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { tap } from 'rxjs/operators';
import { Address } from './address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  formData: Address = new Address();
  readonly baseURL = 'https://localhost:44305/api/Addresses';
  

  constructor(private http: HttpClient) { }

  postAddress() {
    return this.http.post(this.baseURL, this.formData);
  }

  putAddress() {
    return this.http.put(`${this.baseURL}/${this.formData.address_Id}`, this.formData);
  }

  deleteAddress(id: number) {
    return this.http.delete(this.baseURL + '/' + id.toString());
  }

  refreshList(): Observable<Address[]> {

    return this.http.get<Address[]>(this.baseURL)
      .pipe(
        tap(it => {
          //window.alert('am primit adrese '+it.length);
        })
        );
  }

  getAddressById(id: number) {
    return this.http.get<Address>(`${this.baseURL}/${id}`);
  }

}
