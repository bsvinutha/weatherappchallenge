import { style } from '@angular/animations';
import { Component, Inject } from '@angular/core';
import { ForecastService } from '../../services/forecast.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['../../styles.css']
})
export class FetchDataComponent {
  public forecasts: WeatherForecast = new WeatherForecast();
  public cityName: any = '';
  public isHidden = false;

  constructor(
    private forecastService: ForecastService) { }


  currentWeather(result: WeatherForecast) {
  this.forecastService.LoadCurrentWeather(result.city.toLowerCase())
      .subscribe(result => {
        this.forecasts.city = result.city;
        this.forecasts.summary = result.summary;
        this.forecasts.temp = result.temp;
        this.forecasts.minTemp = result.minTemp;
        this.forecasts.maxTemp = result.maxTemp;
        this.forecasts.humidity = result.humidity;
        this.forecasts.wind = result.wind;
      });
    if (this.forecasts != null) {
      this.isHidden = true;
    }

  }
}

export class WeatherForecast {
  city!: string;
  temp!: number;
  summary!: string;
  minTemp!: number;
  maxTemp!: number;
  humidity!: number;
  wind!: number;
}
