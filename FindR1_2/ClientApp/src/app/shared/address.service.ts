import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Address } from './address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  formData: Address = new Address();
  readonly baseURL = 'https://localhost:44305/api/Addresses';
  list: Address[];

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

  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res => this.list = res as Address[]);
    alert("A mers!!");
    alert(typeof (this.list));
  }

}
