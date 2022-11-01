import { Component, Inject} from '@angular/core';
import { GarageService } from './shared/services/garage.service';
import { CarInfoService } from './shared/services/carinfo.service';
import { HttpClient } from '@angular/common/http';
import { Car } from './shared/models/Car';
import { Garage } from './shared/models/Garage';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor(){
    
  }
}
