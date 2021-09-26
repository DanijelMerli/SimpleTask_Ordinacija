import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DentistService {
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  login(code: string): Observable<any> {
    const loginModel = {
      code: code,
    };

    return this.http.post<any>(this.apiUrl + 'Dentist/Login', loginModel);
  }
}
