import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TimeResoultDto } from '../models/time-resoult-dto';

@Injectable({
  providedIn: 'root'
})
export class HttpTravelCalculatorService {

  constructor(private http: HttpClient) { }
  url: string = "https://localhost:7004"

  getCalculateKphWithKilometers(averageSpeed: number, distance: number): Observable<TimeResoultDto> {
    return this.http.get<TimeResoultDto>(this.url + "/" + "travelCalculatorKilomitersPerHour" + "/" + "getSummaryWithKilometers",
      { params: { speed: averageSpeed, distance: distance } });
  }

  getCalculateKphWithKilometersAndConsumption(averageSpeed: number, distance: number, averageFuelConsumption: number, calculateLPG: boolean): Observable<TimeResoultDto> {
    return this.http.get<TimeResoultDto>(this.url + "/" + "travelCalculatorKilomitersPerHour" + "/" + "getSummaryWithKilometers",
      { params: { speed: averageSpeed, distance: distance, combustion: averageFuelConsumption, LPGCombustion: calculateLPG } });
  }



  getCalculateKphWithMiles(averageSpeed: number, distance: number): Observable<TimeResoultDto> {
    return this.http.get<TimeResoultDto>(this.url + "/" + "travelCalculatorKilomitersPerHour" + "/" + "getSummaryWithMiles",
      { params: { speed: averageSpeed, distance: distance } });
  }

  getCalculateKphWithMilesAndConsumption(averageSpeed: number, distance: number, averageFuelConsumption: number, calculateLPG: boolean): Observable<TimeResoultDto> {
    return this.http.get<TimeResoultDto>(this.url + "/" + "travelCalculatorKilomitersPerHour" + "/" + "getSummaryWithMiles",
      { params: { speed: averageSpeed, distance: distance, combustion: averageFuelConsumption, LPGCombustion: calculateLPG } });
  }


  getCalculateMphWithMiles(averageSpeed: number, distance: number): Observable<TimeResoultDto> {
    return this.http.get<TimeResoultDto>(this.url + "/" + "travelCalculatorMilesPerHour" + "/" + "getSummaryWithMiles",
      { params: { speed: averageSpeed, distance: distance } });
  }

  getCalculateMphWithMilesAndConsumption(averageSpeed: number, distance: number, averageFuelConsumption: number, calculateLPG: boolean): Observable<TimeResoultDto> {
    return this.http.get<TimeResoultDto>(this.url + "/" + "travelCalculatorMilesPerHour" + "/" + "getSummaryWithMiles",
      { params: { speed: averageSpeed, distance: distance, combustion: averageFuelConsumption, LPGCombustion: calculateLPG } });
  }



  getCalculateMphWithKilometers(averageSpeed: number, distance: number): Observable<TimeResoultDto> {
    return this.http.get<TimeResoultDto>(this.url + "/" + "travelCalculatorMilesPerHour" + "/" + "getSummaryWithKilometers",
      { params: { speed: averageSpeed, distance: distance } });
  }

  getCalculateMphWithKilometersAndConsumption(averageSpeed: number, distance: number, averageFuelConsumption: number, calculateLPG: boolean): Observable<TimeResoultDto> {
    return this.http.get<TimeResoultDto>(this.url + "/" + "travelCalculatorMilesPerHour" + "/" + "getSummaryWithKilometers",
      { params: { speed: averageSpeed, distance: distance, combustion: averageFuelConsumption, LPGCombustion: calculateLPG } });
  }
}
