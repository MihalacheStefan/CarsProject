import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarDTO } from './CarDTO';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private configUrl = 'http://localhost:61109/api/values/5';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };
  constructor(private http: HttpClient) { }

  getCars(): Observable<CarDTO> {
    return this.http.get<CarDTO>(this.configUrl);
  }
  deleteCar(carDTO: CarDTO): Observable<{}>  {
    return this.http.put(this.configUrl, carDTO);
  }
}
