import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { TimeSpanDto } from 'src/app/dtos/time-span-dto';
import { AppointmentService } from 'src/app/services/appointment.service';

@Component({
  selector: 'new-reservation',
  templateUrl: './new-reservation.component.html',
  styleUrls: ['./new-reservation.component.css'],
})
export class NewReservationComponent implements OnInit {
  appointmentForm: FormGroup;
  todayDate: Date = new Date();
  availableTimes: TimeSpanDto[];

  constructor(private appointmentService: AppointmentService) {}

  ngOnInit(): void {
    this.appointmentForm = new FormGroup({
      duration: new FormControl(undefined, Validators.required),
      date: new FormControl(undefined, Validators.required),
      time: new FormControl({ value: '', disabled: true }, Validators.required),
      email: new FormControl(undefined, [
        Validators.required,
        //Validators.email,
        //Validators.email accepts inputs like name@domain (without TLD) so we need regex
        Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
      ]),
      jmbg: new FormControl(undefined, [
        Validators.required,
        Validators.minLength(13),
        Validators.maxLength(13),
        Validators.pattern('^[0-9]*$'), //consists only of digits
      ]),
    });
  }

  getAvailable() {
    let duration: AbstractControl = this.appointmentForm.get('duration');
    let date: AbstractControl = this.appointmentForm.get('date');
    let time: AbstractControl = this.appointmentForm.get('time');

    if (duration.valid && date.valid) {
      this.appointmentService
        .getAvailableHours(duration.value, new Date(date.value).toISOString())
        .subscribe((data) => {
          this.availableTimes = [];
          data.forEach(t => {
            this.availableTimes.push(new TimeSpanDto(t.hours, t.minutes, t.ticks));
          });
          time.enable();
        });
    } else {
      time.disable();
    }
  }

  send() {}
}
