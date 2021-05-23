import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class ConverterComponent {
  public response: TemperatureResult;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TemperatureResult>(baseUrl + 'converter').subscribe(result => {
      this.response = result;
    }, error => console.error(error));
  }
}

interface TemperatureResult {
  unit: string;
  temperature: number;
}
