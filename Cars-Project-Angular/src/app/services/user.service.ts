import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDTO } from '../DTOs/DTOs';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiUrl = 'http://localhost:61109/api/users';
    private httpOptions = {
    headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Accept': 'application/json',
        'withCredentials': 'true'
        })
    };
    constructor(private http: HttpClient) { }

    getUsers(): Observable<UserDTO[]> {
        return this.http.get<UserDTO[]>(this.apiUrl, this.httpOptions);
    }

    getUser(name: string): Observable<UserDTO> {
        const currentUrl = `${this.apiUrl}/${name}`;
        return this.http.get<UserDTO>(currentUrl, this.httpOptions);
    }

    addUser(userDTO: UserDTO): Observable<UserDTO> {
        return this.http.post<UserDTO>(this.apiUrl, userDTO, this.httpOptions);
    }

    updateUser(userDTO: UserDTO): Observable<UserDTO>  {
        return this.http.put<UserDTO>(this.apiUrl, userDTO, this.httpOptions);
    }

    deleteUser(name: string) {
        const currentUrl = `${this.apiUrl}/${name}`;
        return this.http.delete(currentUrl, this.httpOptions);
    }
}
