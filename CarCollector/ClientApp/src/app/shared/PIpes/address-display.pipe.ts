import { Pipe, PipeTransform } from '@angular/core';
import { Garage } from '../models/Garage';

@Pipe({
  name: 'addressDisplay'
})
export class AddressDisplayPipe implements PipeTransform {

  transform(garage: Garage): string {
    return (garage.streetaddr ?? "") + " " + (garage.city ?? "") + ", " + (garage.state ?? "") + " " + (garage.zipcode ?? "");
  }

}
