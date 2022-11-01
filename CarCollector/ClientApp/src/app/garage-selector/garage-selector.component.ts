import { Component } from '@angular/core';
import { Car } from '../shared/models/Car';
import { Garage } from '../shared/models/Garage';
import { GarageService } from '../shared/services/garage.service';

@Component({
  selector: 'app-garage-selector',
  templateUrl: './garage-selector.component.html',
  styleUrls: ['./garage-selector.component.css']
})
export class GarageSelectorComponent {
  garages: Garage[] = [];
  selectedGarage: Garage | undefined;

  constructor(private garageService: GarageService) { 
    this.garages = this.garageService.getGarages();
    this.selectedGarage = this.garageService.getActiveGarage();
    this.garageService.garagesChanged.subscribe(value => {
      if(value){
        this.garages = this.garageService.getGarages();
    }});
    this.garageService.activeGarageChanged.subscribe(value => {
      if(value){
        this.selectedGarage = this.garageService.getActiveGarage();
      }
    })
  }

  updateSelectedGarage(): void{
    if(this.selectedGarage){
      this.garageService.setActiveGarage(this.selectedGarage);
    }
  }
}
