import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, Injectable } from '@angular/core';
import { AlertifyService } from './services/alertify.service';

@Injectable({
  providedIn: 'root',
})
export class AppErrorHandler implements ErrorHandler {
  constructor(private alertify: AlertifyService) {}

  handleError(error: any): void {
    console.log(error);
    if (error.error && typeof error.error == 'string') {
      this.alertify.error(error.error);
    } else {
      this.alertify.error(
        'Status code: ' + error.status + '</br>Message: ' + error.message
      );
    }
  }
}
