import { Component, OnInit } from '@angular/core';
import { Address } from '../shared/address.model';
import { AddressService } from '../shared/address.service';
import { CompleteAddress } from '../shared/complete-address.model';
import { CompleteAddressService } from '../shared/complete-address.service';
import { CompleteHousing } from '../shared/complete-housing.model';
import { CompleteHousingService } from '../shared/complete-housing.service';
import { Housing } from '../shared/housing.model';
import { HousingService } from '../shared/housing.service';

@Component({
  selector: 'app-housing',
  templateUrl: './housing.component.html',
  styles: []
})
export class HousingComponent implements OnInit {

  constructor(public service: HousingService, public addressesService: CompleteAddressService, public as: AddressService) { }

  housingsList: Housing[];
  completeAddressesList: CompleteAddress[];
  adressesList: Address[];

  completeHousingsList: CompleteHousing[];

  ngOnInit() {
    this.refreshListNow();
  }

  refreshListNow() {
    this.service.refreshList().subscribe( 
      add => this.housingsList = add
    );
    this.addressesService.refreshList().subscribe(
      add => this.completeAddressesList = add
    );
    this.as.refreshList().subscribe(
      add => this.adressesList = add
    );
    //this.completeHousingsList = this.chs.getCompleteHousing(); 
  }

  populateForm(selectRecord) {
    this.service.formData = Object.assign({}, selectRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure you want to delete this record?')) {
      this.service.deleteHousing(id).subscribe(
        res => {
          this.service.refreshList();
        },
        err => { console.log(err); }
      );
    }
  }
  
}
