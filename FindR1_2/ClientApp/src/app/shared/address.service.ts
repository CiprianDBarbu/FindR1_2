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
    return this.http.put('${this.baseURL}/${this.formData.Address_Id}', this.formData);
  }

  deleteAddress(id: number) {
    return this.http.delete('${this.baseUrl}/${id}');
  }

  refreshList(): Observable<Address[]> {

    return this.http.get<Address[]>(this.baseURL)
      .pipe(
        tap(it => {
          window.alert('am primit adrese '+it.length);
        })
        )
      ;

      //.toPromise()
      //.then(res => this.list = res as Address[]);
    //alert("A mers!!");
    //alert(typeof (this.list));
  }

}
