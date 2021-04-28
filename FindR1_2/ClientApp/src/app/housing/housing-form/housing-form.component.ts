import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Address } from '../../shared/address.model';
import { AddressService } from '../../shared/address.service';
import { CompleteAddress } from '../../shared/complete-address.model';
import { CompleteAddressService } from '../../shared/complete-address.service';
import { Housing } from '../../shared/housing.model';
import { HousingService } from '../../shared/housing.service';

@Component({
  selector: 'app-housing-form',
  templateUrl: './housing-form.component.html',
  styles: []
})
export class HousingFormComponent implements OnInit {

  housingsList: Housing[];
  completeAddressesList: CompleteAddress[];
  addressesList: Address[];

  constructor(public hs: HousingService, public cas: CompleteAddressService, public as: AddressService) { }

  ngOnInit() {
    this.as.refreshList().subscribe(
      add => this.addressesList = add
    );
  }

  onSubmit(form: NgForm) {
    if (this.hs.formData.housing_Id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }
    
  insertRecord(form: NgForm) {
    this.hs.postHousing().subscribe(err => { console.log(err);});
    this.cas.postCompleteAddresses().subscribe(
      res => {
        this.resetForm(form);
        this.refreshListNow();
      },
      err => { console.log(err);}
    );
  }
  updateRecord(form: NgForm) {
    this.hs.putHousing().subscribe(err => { console.log(err); });
    this.cas.putCompleteAddresses().subscribe(
      res => {
        this.resetForm(form);
        this.refreshListNow();
      },
      err => { console.log(err);}
    );
  }

  refreshListNow() {
    this.hs.refreshList().subscribe(
      add => this.housingsList = add
    );
    this.cas.refreshList().subscribe(
      add => this.completeAddressesList = add
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.hs.formData = new Housing();
    this.cas.formData = new CompleteAddress();
  }

}
