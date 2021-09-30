import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  FormGroupDirective,
  Validators,
} from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AppointmentCreateDto } from 'src/app/dtos/appointment-create-dto';
import { TimeSpanDto } from 'src/app/dtos/time-span-dto';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AppointmentService } from 'src/app/services/appointment.service';
import { AppointmentDialogComponent } from '../appointment-dialog/appointment-dialog.component';

@Component({
  selector: 'new-appointment',
  templateUrl: './new-appointment.component.html',
  styleUrls: ['./new-appointment.component.css'],
})
export class NewAppointmentComponent implements OnInit {
  appointmentForm: FormGroup;
  todayDate: Date = new Date();
  availableTimes: TimeSpanDto[] = [];
  
  weekendsDatesFilter = (d: Date): boolean => {
      const day = d.getDay();

      // saturday and sunday
      return day !== 0 && day !== 6 ;
  }

  constructor(
    private appointmentService: AppointmentService,
    private alertifyService: AlertifyService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.initForm();
  }

  private initForm() {
    this.appointmentForm = new FormGroup({
      duration: new FormControl(undefined, Validators.required),
      date: new FormControl(undefined, Validators.required),
      time: new FormControl({ value: '', disabled: true }, Validators.required),
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

  getAvailable() {
    let duration: AbstractControl = this.appointmentForm.get('duration');
    let date: AbstractControl = this.appointmentForm.get('date');
    let time: AbstractControl = this.appointmentForm.get('time');

    if (duration.valid && date.valid) {
      this.appointmentService
        .getAvailableHours(duration.value, new Date(date.value).toISOString())
        .subscribe((data) => {
          this.availableTimes = [];
          data.forEach((t: TimeSpanDto) => {
            this.availableTimes.push(
              new TimeSpanDto(t.hours, t.minutes, t.ticks)
            );
          });
        });
    } else {
      time.disable();
    }
  }

  // passing FormGroupDirective because it's the only way to clear validation errors after submit
  submit(form: FormGroupDirective) {
    if (form.valid) {
      let formVal: AppointmentCreateDto = form.value;

      let ap = new AppointmentCreateDto(
        formVal.duration,
        new Date(formVal.date).toISOString(),
        formVal.time,
        formVal.email,
        formVal.jmbg
      );

      this.appointmentService.submitAppointment(ap).subscribe((data) => {
        this.alertifyService.success("Appointment created");
        form.resetForm();
      });
    }
  }

  openAppointmentDialog() {
    let dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;

    this.dialog.open(AppointmentDialogComponent, dialogConfig)
  }
}
