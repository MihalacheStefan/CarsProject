import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EngineDTO } from '../DTOs/DTOs';


@Injectable ({
    providedIn: 'root'
})
export class EngineService {
    private apiUrl = 'http://localhost:61109/api/engines';
    private httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
          'Accept': 'application/json',
          'withCredentials': 'true'
        })
      };
    constructor(private http: HttpClient) {  }

    getEngines(): Observable<EngineDTO[]> {
        return this.http.get<EngineDTO[]>(this.apiUrl, this.httpOptions);
    }

    getEngine(id: string):  Observable<EngineDTO> {
        const currentUrl = `${this.apiUrl}/${id}`;
        return this.http.get<EngineDTO>(currentUrl, this.httpOptions);
    }

    addEngine(engineDTO: EngineDTO): Observable<EngineDTO> {
        return this.http.post<EngineDTO>(this.apiUrl, engineDTO, this.httpOptions);
    }
    
    updateEngine(engineDTO: EngineDTO): Observable<EngineDTO>  {
        return this.http.put<EngineDTO>(this.apiUrl, engineDTO, this.httpOptions);
    }
    
    deleteEngine(id: string) {
        const currentUrl = `${this.apiUrl}/${id}`;
        return this.http.delete(currentUrl, this.httpOptions);
    }
}


