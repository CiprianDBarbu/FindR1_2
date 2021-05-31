import { Component, OnInit } from '@angular/core';
import { AddressService } from '../shared/address.service';
import { Advertisement } from '../shared/advertisement.model';
import { AdvertisementService } from '../shared/advertisement.service';
import { ApplicationUser } from '../shared/application-user.model';
import { ApplicationUserService } from '../shared/application-user.service';
import { CompleteAddress } from '../shared/complete-address.model';
import { CompleteAddressService } from '../shared/complete-address.service';
import { Housing } from '../shared/housing.model';
import { HousingService } from '../shared/housing.service';

@Component({
  selector: 'app-find-housing',
  templateUrl: './find-housing.component.html',
  styleUrls: ['./find-housing.component.css']
})
export class FindHousingComponent implements OnInit {

  constructor(public hs: HousingService, public cas: CompleteAddressService, public ads: AdvertisementService, public aus: ApplicationUserService, public as: AddressService) { }

  housingsList: Housing[];
  completeAddressList: CompleteAddress[];
  advertisementsList: Advertisement[];
  usersList: ApplicationUser[];

  ngOnInit() {
    this.getLists();
    
  }

  getLists() {
    this.hs.refreshList().subscribe(
      add => this.housingsList = add
    );

    this.cas.refreshList().subscribe(
      add => this.completeAddressList = add
    );

    this.ads.refreshList().subscribe(
      add => this.advertisementsList = add
    );

    this.aus.getUsers().subscribe(
      add => this.usersList = add
    );
  }

  findUser(id: string) {
    let user = this.usersList.find(x => x.id == id);

    return `${user.firstName} ${user.lastName}`;
  }

  findHousing(id: number) {
    let housing = this.housingsList.find(h => h.advertisementId == id);

    return housing;
  }

  findCompleteAddress(id: number) {
    let cas = this.completeAddressList.find(ca => ca.housingId == id);

    return cas;
  }

  
}
