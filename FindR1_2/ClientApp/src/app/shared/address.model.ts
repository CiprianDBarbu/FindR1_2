import { ApplicationUser } from "./application-user.model";
import { CompleteAddress } from "./complete-address.model";

export enum ZoneType {
  Urban = "Urban",
  Rural = "Rural",
}

export class Address {
  address_Id: number = 0;
  country: string = "";
  city: string = "";
  zone: ZoneType;
  completeAddresses: CompleteAddress[];
  applicationUsers: ApplicationUser[];
}
