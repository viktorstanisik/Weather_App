import { Component, OnInit } from "@angular/core";
import { City } from "../models/city";
import { WeatherService } from "../services/weather.service";


@Component({
  selector: 'app-get-weather',
  templateUrl: './get-weather.component.html',
  styleUrls: ['./get-weather.component.css']
})
export class GetWeatherComponent implements OnInit {
  model: any = {};
  cities: City[];
  invalidCityName ='';
  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
  }

 getWeather(){
    this.weatherService.GetWeather(this.model).subscribe(response =>{
      this.cities = response
    }, error => {
      if(error.message = "Invalid City Name, Please enter valid City Name!!") {
        this.invalidCityName = error.message;
      } 
      console.log(error);
    })
    this.invalidCityName = '';

   }
   
}
