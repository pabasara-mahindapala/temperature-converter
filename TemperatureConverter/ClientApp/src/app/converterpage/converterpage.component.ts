import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-converter-page',
  templateUrl: './converterpage.component.html'
})
export class ConverterPageComponent {
  public response: TemperatureResult[];
  valueModel: number;
  unitModel: string = "celsius";

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  convert() {
    this.http.get<TemperatureResult[]>(this.baseUrl + 'converter?unit=' + this.unitModel + '&value=' + this.valueModel).subscribe(result => {
      this.response = result;
    }, error => console.error(error));
  }

  clear() {
    this.response = null;
    this.valueModel = null;
    this.unitModel = "celsius";
  }
}

interface TemperatureResult {
  unit: string;
  temperature: number;
}
