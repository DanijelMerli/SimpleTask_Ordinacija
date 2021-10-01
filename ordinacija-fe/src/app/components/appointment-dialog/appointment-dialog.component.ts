import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AppointmentService } from 'src/app/services/appointment.service';
import { UserDataDto } from 'src/app/dtos/user-data-dto';
import { AppointmentDetails } from 'src/app/entities/appointment-details';
import { TimeSpan } from 'src/app/entities/time-span';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-appointment-dialog',
  templateUrl: './appointment-dialog.component.html',
  styleUrls: ['./appointment-dialog.component.css'],
})
export class AppointmentDialogComponent implements OnInit {
  appointmentForm: FormGroup;
  appointment: AppointmentDetails;

  constructor(
    private appointmentService: AppointmentService,
    private dialogRef: MatDialogRef<AppointmentDialogComponent>,
    private alertify: AlertifyService
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.dialogRef.afterClosed().subscribe(() => this.afterClosed());
  }

  private initForm() {
    this.appointmentForm = new FormGroup({
      email: new FormControl(undefined, [
        Validators.required,
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

  submit() {
    if (this.appointmentForm.valid) {
      this.appointmentService
        .getAppointment(this.appointmentForm.value as UserDataDto)
        .subscribe((data) => {
          let dateStart = new Date(data.dateAndTime);
          let dateEnd = new Date(
            0,
            0,
            0,
            dateStart.getHours() + data.duration.duration.hours,
            dateStart.getMinutes() + data.duration.duration.minutes
          );

          this.appointment = new AppointmentDetails(
            data.id,
            dateStart,
            dateEnd,
            new TimeSpan(
              data.duration.duration.hours,
              data.duration.duration.minutes,
              0
            )
          );
        });
    }
  }

  cancelAppointment() {
    if (this.appointment) {
      this.appointmentService
        .cancelAppointment(this.appointment.id)
        .subscribe(() => {
          this.alertify.success("Appointment successfully cancelled");
          this.close();
        });
    }
  }

  close() {
    this.dialogRef.close();
  }

  private afterClosed() {
    this.appointment = undefined;
  }
}
