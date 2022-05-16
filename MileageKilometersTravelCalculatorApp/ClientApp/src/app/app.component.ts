import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { TimeResoultDto } from "./models/time-resoult-dto";
import { HttpTravelCalculatorService } from './services/http-travel-calculator.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  url: string = "https://localhost:7004"

  averageSpeed: number = 0;
  averageFuelConsumption: number | null = null;
  meter: string = "";
  distance: number = 0;
  units: string = "";
  calculateLPG: boolean = false;

  resoultTable: boolean = false;

  timeResoult: TimeResoultDto = {
    hours: 0,
    minutes: 0,
    fuelConsumption: 0,
    lpgConsumption: 0,
    comment: ""
  };



  constructor(private httpService: HttpTravelCalculatorService) { }



  switchResoult() {
    if (this.resoultTable == false) {
      this.resoultTable = true;
    }
  }

  submit() {
    if (this.meter == "Km/h" && this.units == "Kilometry") {
      this.httpService.getCalculateKphWithKilometers(this.averageSpeed, this.distance)
        .subscribe(resoult => this.timeResoult = resoult);

      if (this.averageFuelConsumption != null) {
        this.httpService.getCalculateKphWithKilometersAndConsumption(this.averageSpeed, this.distance, this.averageFuelConsumption, this.calculateLPG)
          .subscribe(resoult => this.timeResoult = resoult);
      }
    }

    if (this.meter == "Km/h" && this.units == "Mile") {
      this.httpService.getCalculateKphWithMiles(this.averageSpeed, this.distance)
        .subscribe(resoult => this.timeResoult = resoult);

      if (this.averageFuelConsumption != null) {
        this.httpService.getCalculateKphWithMilesAndConsumption(this.averageSpeed, this.distance, this.averageFuelConsumption, this.calculateLPG)
          .subscribe(resoult => this.timeResoult = resoult);
      }
    }

    if (this.meter == "Mph" && this.units == "Mile") {
      this.httpService.getCalculateMphWithMiles(this.averageSpeed, this.distance)
        .subscribe(resoult => this.timeResoult = resoult);

      if (this.averageFuelConsumption != null) {
        this.httpService.getCalculateMphWithMilesAndConsumption(this.averageSpeed, this.distance, this.averageFuelConsumption, this.calculateLPG)
          .subscribe(resoult => this.timeResoult = resoult);
      }
    }

    if (this.meter == "Mph" && this.units == "Kilometry") {
      this.httpService.getCalculateMphWithKilometers(this.averageSpeed, this.distance)
        .subscribe(resoult => this.timeResoult = resoult);

      if (this.averageFuelConsumption != null) {
        this.httpService.getCalculateMphWithKilometersAndConsumption(this.averageSpeed, this.distance, this.averageFuelConsumption, this.calculateLPG)
          .subscribe(resoult => this.timeResoult = resoult);
      }
    }


    this.switchResoult();
    console.log(this.timeResoult);

  }

}
