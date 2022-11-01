import { Injectable } from '@angular/core';
import { Garage } from '../models/Garage';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GarageService {

  private garages: Garage[] = [];
  private activeGarage: Garage | undefined;
  activeGarageChanged = new Subject<boolean>();
  garagesChanged = new Subject<boolean>();
  
  getGarages(): Garage[] {
    return this.garages;
  }

  setGarages(garages: Garage[]): void {
    this.garages = garages;
    this.garagesChanged.next(true);
  }

  getActiveGarage(): Garage | undefined{
    return this.activeGarage;
  }

  setActiveGarage(activeGarage: Garage) {
    this.activeGarage = activeGarage;
    this.activeGarageChanged.next(true);
  }

  setActiveGarageChanged(changed: boolean){
    this.activeGarageChanged.next(changed);
  }

  setGaragesChanged(changed: boolean){
    this.garagesChanged.next(changed);
  }
}