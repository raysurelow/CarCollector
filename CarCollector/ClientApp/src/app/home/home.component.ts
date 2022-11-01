import { Component, Inject } from '@angular/core';
import { CarInfoService } from '../shared/services/carinfo.service';
import { Car } from '../shared/models/Car';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Garage } from '../shared/models/Garage';
import { GarageService } from '../shared/services/garage.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  carInfo: Car[] = [];
  selectedGarage: Garage | undefined;


  constructor(private carInfoService: CarInfoService, private garageService: GarageService, private router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string){
    http.get<Garage[]>(baseUrl + 'garage').subscribe({
      next: (result) => {
        this.garageService.setGarages(result);
        if(!this.garageService.getActiveGarage()){
          this.garageService.setActiveGarage(result[0])
        }
      },
      error: (e) => console.error(e)
    });

    http.get<Car[]>(baseUrl + 'carinfo').subscribe({
      next: (result) => {
        this.carInfoService.setCarInfo(result);
      },
      error: (e) => console.error(e)
    });
    this.carInfo = this.carInfoService.getCarInfo();
    this.carInfoService.carInfoChanged.subscribe(value => {
      if(value){
        this.carInfo = this.carInfoService.getCarInfo()
    }});
    this.selectedGarage = this.garageService.getActiveGarage();
    this.garageService.activeGarageChanged.subscribe(value => {
      if(value){
        this.selectedGarage = this.garageService.getActiveGarage();
    }});
  }

  openMyGarage(){
    this.router.navigateByUrl('/my-garage');
  }
}
