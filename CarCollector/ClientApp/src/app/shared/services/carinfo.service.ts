import { Injectable } from '@angular/core';
import { Car } from '../models/Car';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarInfoService {
  carInfo: Car[] = [];
  carInfoChanged = new Subject<boolean>;
  
  getCarInfo(): Car[]{
    return this.carInfo;
  }

  setCarInfo(carInfo: Car[]): void{
    this.carInfo = carInfo;
    this.setCarInfoChanged(true);
  }

  setCarInfoChanged(changed: boolean): void{
    this.carInfoChanged.next(changed);
  }
}
