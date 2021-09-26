import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'new-reservation',
  templateUrl: './new-reservation.component.html',
  styleUrls: ['./new-reservation.component.css'],
})
export class NewReservationComponent implements OnInit {
  reservationForm: FormGroup;
  todayDate: Date = new Date();

  constructor() {}

  ngOnInit(): void {
    this.reservationForm = new FormGroup({
      duration: new FormControl(),
      date: new FormControl(),
      time: new FormControl(),
    });
  }

  send() {}
}
