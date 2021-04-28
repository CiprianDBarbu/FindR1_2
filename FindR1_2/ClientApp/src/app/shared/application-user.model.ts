export enum GenderType {
  Male = "Male",
  Female = "Female",
  Others = "Others",
}

export class ApplicationUser {
  profilePicture: HTMLImageElement;
  firstName: string;
  lastName: string;
  birthDate: string;
  age: number;
  gender: GenderType;
  details: string;

  addressId: number;

  attendsTo: number;
}
