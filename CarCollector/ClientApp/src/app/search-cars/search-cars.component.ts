import { Component, Inject} from '@angular/core';
import { Car } from '../shared/models/Car';
import { CarInfoService } from '../shared/services/carinfo.service';
import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AddCarModalComponent } from '../add-car-modal/add-car-modal.component';

@Component({
  selector: 'app-search-cars',
  templateUrl: './search-cars.component.html',
  styleUrls: ['./search-cars.component.css']
})
export class SearchCarsComponent {

  public cars: Car[] = [];

  constructor(private carInfoService: CarInfoService, http: HttpClient, @Inject('BASE_URL') baseUrl: string, private matDialog: MatDialog){
    http.get<Car[]>(baseUrl + 'carinfo').subscribe({
      next: (result) => {
        this.cars = result;
        this.carInfoService.setCarInfo(result);
      },
      error: (e) => console.error(e)
    });
  }

  openAddCarModal(car: Car): void{
    this.matDialog.open(AddCarModalComponent, {
      width: '25%',
      data: car
    });
  }

}
