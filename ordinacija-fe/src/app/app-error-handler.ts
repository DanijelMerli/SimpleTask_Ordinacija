import { ErrorHandler, Injectable } from '@angular/core';
import { AlertifyService } from './services/alertify.service';

@Injectable({
  providedIn: 'root',
})
export class AppErrorHandler implements ErrorHandler {
  constructor(private alertify: AlertifyService) {}

  handleError(error: Error): void {
    this.alertify.error(error.error);
  }
}
