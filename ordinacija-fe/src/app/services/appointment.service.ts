import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  sendReservation(reservation): Observable<any> {
    return this.http.post(this.apiUrl, reservation);
  }

  getAvailableHours(duration, date): Observable<any> {
    const params = {
      duration: duration,
      date: date,
    };

    return this.http.get(this.apiUrl + 'Appointment/Hours/', { params: params });
  }
}
