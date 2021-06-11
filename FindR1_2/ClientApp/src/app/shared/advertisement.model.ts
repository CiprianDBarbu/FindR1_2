import { ApplicationUser } from "./application-user.model";
import { Housing } from "./housing.model";

export class Advertisement {
  advertisement_Id: number;
  profileId: string;
  profile: ApplicationUser;
  housing: Housing;
  checkInDate: string;
}
