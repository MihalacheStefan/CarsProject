import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ChassisDTO } from '../DTOs/DTOs';


@Injectable({
  providedIn: 'root'
})
export class ChassisService {
  private apiUrl = 'http://localhost:61109/api/chassis';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Accept': 'application/json',
      'withCredentials': 'true'
    })
  };
  constructor(private http: HttpClient) { }

  getChassis(id: string) {
    const currentUrl = `${this.apiUrl}/${id}`;
    return this.http.get<ChassisDTO>(currentUrl, this.httpOptions);
  }

  addChassis(chassisDTO: ChassisDTO): Observable<ChassisDTO> {
    return this.http.post<ChassisDTO>(this.apiUrl, chassisDTO, this.httpOptions);
  }

  updateChassis(chassisDTO: ChassisDTO): Observable<ChassisDTO>  {
    return this.http.put<ChassisDTO>(this.apiUrl, chassisDTO, this.httpOptions);
  }

  deleteChassis(id: string) {
    const currentUrl = `${this.apiUrl}/${id}`;
    return this.http.delete(currentUrl, this.httpOptions);
  }
}
