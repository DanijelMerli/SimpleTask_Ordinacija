import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.css'],
})
export class LoginDialogComponent implements OnInit {
  form: FormGroup;
  description: string;

  constructor(
    private dialogRef: MatDialogRef<LoginDialogComponent>,
    private alertify: AlertifyService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.form = new FormGroup({
      code: new FormControl(undefined, Validators.required),
    });
  }

  login() {
    if (this.form.valid) {
      this.authService
        .logIn(this.form.controls['code'].value)
        .subscribe((data) => {
          this.authService.storeToken(data.token);
          this.alertify.success('Logged in successfully');
          this.dialogRef.close();
        });
    }
  }

  close() {
    this.dialogRef.close();
  }
}
