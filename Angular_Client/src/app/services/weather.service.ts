import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { City } from '../models/city';
import { CityRequest } from '../models/cityRequest';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  city: City[] = [];
  cityRequest: CityRequest;

  constructor(private http: HttpClient) {}

  GetWeather(model: CityRequest) {
    return this.http
      .post<City[]>(environment.apiUrl + 'Weather/getweatherdata', model)
      .pipe(
        map((response) => {
         return this.city = response;
        })
      );
  }
}
