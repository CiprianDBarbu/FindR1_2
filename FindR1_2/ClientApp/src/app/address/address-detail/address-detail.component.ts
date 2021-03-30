import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Address } from '../../shared/address.model';
import { AddressService } from '../../shared/address.service';

export enum ZoneType {
  Urban = "Urban",
  Rural = "Rural",
}


@Component({
  selector: 'app-address-detail',
  templateUrl: './address-detail.component.html',
  styles: []
})
export class AddressDetailComponent implements OnInit {

  eZoneType = ZoneType;
  list: Address[];

  constructor(public service: AddressService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.address_Id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postAddress().subscribe(
      res => {
        this.resetForm(form);
        this.refreshListNow();
      },
      err => { console.log(err);}
    );
  }

  refreshListNow() {
    this.service.refreshList().subscribe(
      add => this.list = add
    );
  }

  updateRecord(form: NgForm) {
    this.service.putAddress().subscribe(
      res => {
        this.resetForm(form);
        this.refreshListNow();
      },
      err => { console.log(err);}
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Address();
  }
}
