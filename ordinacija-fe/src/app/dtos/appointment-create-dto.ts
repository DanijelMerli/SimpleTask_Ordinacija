export class AppointmentCreateDto {
  duration: number;
  date: string;
  time: number;
  jmbg: string;
  email: string;

  constructor(
    duration: number,
    date: string,
    time: number,
    email: string,
    jmbg: string,
  ) {
      this.duration = duration;
      this.date = date;
      this.time = time;
      this.email = email;
      this.jmbg = jmbg;
  }
}
