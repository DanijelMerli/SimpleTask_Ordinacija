import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-appointment-dialog',
  templateUrl: './appointment-dialog.component.html',
  styleUrls: ['./appointment-dialog.component.css']
})
export class AppointmentDialogComponent implements OnInit {
  appointmentForm: FormGroup;
  
  constructor() { }

  ngOnInit(): void {
    this.initForm();
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
    }) 
  }

  submit(){}
}
