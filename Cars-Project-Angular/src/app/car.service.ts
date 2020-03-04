import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarDTO } from './CarDTO';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private configUrl = 'http://localhost:61109/api/values/5';

  constructor(private http: HttpClient) { }

  getCars(): Observable<CarDTO> {
    return this.http.get<CarDTO>(this.configUrl);
  }
}
