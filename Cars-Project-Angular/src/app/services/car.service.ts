import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarDTO } from '../DTOs/DTOs';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private configUrl = 'http://localhost:61109/api/values/C8501896-21C9-4165-CA00-08D7C2B0A910';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };
  constructor(private http: HttpClient) { }

  getCars(): Observable<CarDTO> {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Accept': 'application/json',
        'withCredentials': 'true'
      })
    };
    return this.http.get<CarDTO>(this.configUrl, httpOptions);
  }
  deleteCar(carDTO: CarDTO): Observable<{}>  {
    return this.http.put(this.configUrl, carDTO);
  }
}
