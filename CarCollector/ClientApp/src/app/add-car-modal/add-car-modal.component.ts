import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Car } from '../shared/models/Car';
import { HttpClient, HttpEventType, HttpHeaders } from '@angular/common/http';
import { GarageService } from '../shared/services/garage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-car-modal',
  templateUrl: './add-car-modal.component.html',
  styleUrls: ['./add-car-modal.component.css']
})
export class AddCarModalComponent {
  make: string = "";
  model: string = "";
  year: number | undefined;
  description: string = "";
  image: string = "";
  files:  any[] = [];
  uploadButtonDisabled: boolean = true;
  message: string = "";

  constructor(public dialogRef: MatDialogRef<AddCarModalComponent>, @Inject(MAT_DIALOG_DATA) public data: Car, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, 
              private garageService: GarageService, private router: Router) { 
    if(data){
      this.make = data.make;
      this.model = data.model;
      this.year = data.year;
      this.description = data.description;
      this.image = data.image;
    }
  }

  createCar(){
    let newCar = {
      CarId: null,
      Make: this.make,
      Model: this.model,
      Year: this.year,
      Description: this.description,
      Image: this.image
    }
    const garage = this.garageService.getActiveGarage();
    this.http.post<any>(this.baseUrl + 'car', {car: newCar, garageId: garage?.garageId}).subscribe({
      next: (result) => {
        newCar.CarId = result;
        garage?.cars.push({
          carId: result,
          make: this.make,
          model: this.model,
          year: this.year,
          description: this.description,
          image: this.image
        });
        this.closeModalAndOpenGarage();
      }, 
      error: (e) => console.error(e)
    });
  }

  closeModalAndOpenGarage(){
    this.router.navigateByUrl('/my-garage');
    this.dialogRef.close();
  }

  onFileChanged(event: any) {
    this.image = "";
    this.files = event.target.files;
    if (this.files && this.files.length > 0) {
      this.uploadButtonDisabled = false;
    }
  }

  uploadFile(){
    if (!this.files || this.files.length === 0) {
      return;
    }
    let fileToUpload = <File>this.files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post(this.baseUrl + 'upload', formData).subscribe({
        next: (result) => {
          this.image = JSON.parse(JSON.stringify(result)).fileURL;
          this.message = "Uploaded";
        },
        error: (e) => console.log(e)
    });
  }
}