import { Component, Inject } from '@angular/core';
import { Garage } from '../shared/models/Garage';
import { GarageService } from '../shared/services/garage.service';
import { MatDialog } from '@angular/material/dialog';
import { AddCarModalComponent } from '../add-car-modal/add-car-modal.component';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-my-garage',
  templateUrl: './my-garage.component.html',
  styleUrls: ['./my-garage.component.css']
})
export class MyGarageComponent {
  selectedGarage: Garage | undefined;

  constructor(private garageService: GarageService, private matDialog: MatDialog, http: HttpClient, @Inject('BASE_URL') baseUrl: string){
    this.selectedGarage = this.garageService.getActiveGarage();
    this.garageService.activeGarageChanged.subscribe(value => {
      if(value){
        this.selectedGarage = this.garageService.getActiveGarage();
    }});
  }

  openAddCarModal(): void{
    this.matDialog.open(AddCarModalComponent, {
      width: '25%'
    });
  }
}
