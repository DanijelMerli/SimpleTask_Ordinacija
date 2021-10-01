import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppointmentCreateDto } from '../dtos/appointment-create-dto';
import { UserDataDto } from '../dtos/user-data-dto';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /*
  even though this method is idempotent, we're using POST instead of GET
  so we avoid sending personal data trough url params
  sidenote: it is possible to send data in request body with GET, but it is not standardized that way
  in this case POST serves the purpose of 'this action isn’t worth standardizing.'*/
  getAppointment(userData: UserDataDto): Observable<any> {
    return this.http.post(this.apiUrl + 'Appointment/Get/', userData);
  }

  submitAppointment(appointment: AppointmentCreateDto): Observable<any> {
    return this.http.post(this.apiUrl + 'Appointment/Create/', appointment);
  }

  cancelAppointment(id: number): Observable<any> {
    return this.http.post(this.apiUrl + 'Appointment/Cancel/', id);
  }

  getAvailableHours(duration, date): Observable<any> {
    const params = {
      duration: duration,
      date: date,
    };

    return this.http.get(this.apiUrl + 'Appointment/Hours/', {
      params: params,
    });
  }
}
