import { ApplicationUser } from "./application-user.model";
import { CompleteAddress } from "./complete-address.model";

export enum ZoneType {
  Urban = "Urban",
  Rural = "Rural",
}

export class Address {
  Address_Id: number = 0;
  Country: string = "";
  City: string = "";
  Zone: ZoneType;
  completeAddresses: CompleteAddress[];
  applicationUsers: ApplicationUser[];
}
