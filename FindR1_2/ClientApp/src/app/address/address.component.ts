import { Component, OnInit } from '@angular/core';
import { Address } from '../shared/address.model';
import { AddressService } from '../shared/address.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styles: []
})
export class AddressComponent implements OnInit {

  constructor(public service: AddressService) { }

  list: Address[];

  ngOnInit() {
    //alert("TEST BEFORE INIT!");
    this.refreshListNow();
    //alert("TEST AFTER INIT!");
  }

  refreshListNow() {
    this.service.refreshList().subscribe(
      add => this.list = add
    );
  }

  populateForm(selectedRecord) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure you want to delete this record?')) {
      this.service.deleteAddress(id).subscribe(
        res => {
          this.service.refreshList();
        },
        err => { console.log(err);}
      );
    }
  }

}
