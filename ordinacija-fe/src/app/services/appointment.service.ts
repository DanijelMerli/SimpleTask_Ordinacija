import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppointmentCreateDto } from '../dtos/appointment-create-dto';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  submitAppointment(appointment: AppointmentCreateDto): Observable<any> {
    return this.http.post(this.apiUrl + 'Appointment/Create/', appointment);
  }

  getAvailableHours(duration, date): Observable<any> {
    const params = {
      duration: duration,
      date: date,
    };

    return this.http.get(this.apiUrl + 'Appointment/Hours/', { params: params });
  }
}
