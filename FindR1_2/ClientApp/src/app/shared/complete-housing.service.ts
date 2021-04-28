import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Address } from './address.model';
import { AddressService } from './address.service';
import { CompleteAddress } from './complete-address.model';
import { CompleteAddressService } from './complete-address.service';
import { CompleteHousing } from './complete-housing.model';
import { Housing } from './housing.model';
import { HousingService } from './housing.service';

@Injectable({
  providedIn: 'root'
})
export class CompleteHousingService {

  constructor(public hs: HousingService, public cas: CompleteAddressService, public as: AddressService) { }

  housingsList: Housing[];
  completeAddressesList: CompleteAddress[];
  
  completeHousingsList: CompleteHousing[];

  getCompleteHousing(): CompleteHousing[] {
    
    this.hs.refreshList().subscribe(
      add => this.housingsList = add
    );
    this.cas.refreshList().subscribe(
      add => {
        this.completeAddressesList = add;

        for (var i = 1; i <= this.completeAddressesList.length; i++) {
          var housing = new CompleteHousing();
          alert("inceput de for");
          housing.price = this.housingsList[i].price;
          housing.noOfRooms = this.housingsList[i].noOfRooms;
          housing.isTaken = this.housingsList[i].isTaken;
          housing.street = this.completeAddressesList[i].street;
          housing.floor = this.completeAddressesList[i].floor;
          //this.as.getAddressById(this.completeAddressesList[i].addressId).subscribe(
          //  add => housing.city = add.city
          //);
          this.completeHousingsList.push(housing);
          
        }
      }
    )

    return this.completeHousingsList;
  }

}
