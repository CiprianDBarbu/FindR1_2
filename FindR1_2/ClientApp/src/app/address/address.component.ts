import { Component, OnInit } from '@angular/core';
import { AddressService } from '../shared/address.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styles: []
})
export class AddressComponent implements OnInit {

  constructor(public service: AddressService) { }

  ngOnInit() {
    alert("TEST BEFORE INIT!");
    this.service.refreshList();
    alert("TEST AFTER INIT!");
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
