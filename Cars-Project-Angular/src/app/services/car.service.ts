import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarDTO } from '../DTOs/DTOs';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private apiUrl = 'http://localhost:61109/api/cars';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Accept': 'application/json',
      'withCredentials': 'true'
    })
  };
  constructor(private http: HttpClient) { }

  getCars(): Observable<CarDTO[]> {
    return this.http.get<CarDTO[]>(this.apiUrl, this.httpOptions);
  }

  getCar(brand: string): Observable<CarDTO> {
    const currentUrl = `${this.apiUrl}/${brand}`;
    return this.http.get<CarDTO>(currentUrl, this.httpOptions);
  }

  addCar(carDTO: CarDTO): Observable<CarDTO> {
    return this.http.post<CarDTO>(this.apiUrl, carDTO, this.httpOptions);
  }

  updateCar(carDTO: CarDTO): Observable<CarDTO>  {
    return this.http.put<CarDTO>(this.apiUrl, carDTO, this.httpOptions);
  }

  deleteCar(brand: string) {
    const currentUrl = `${this.apiUrl}/${brand}`;
    return this.http.delete(currentUrl, this.httpOptions);
  }
}
