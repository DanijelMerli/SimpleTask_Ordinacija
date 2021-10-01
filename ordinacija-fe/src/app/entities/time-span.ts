export class TimeSpan {
  hours: number;
  minutes: number;
  ticks: number;

  constructor(hours: number, minutes: number, ticks: number) {
    this.hours = hours;
    this.minutes = minutes;
    this.ticks = ticks;
  }

  toString(): string {
    return this.hours
      .toLocaleString('en-US', {
        minimumIntegerDigits: 2,
        useGrouping: false,
      })
      .concat(
        ':',    
        this.minutes.toLocaleString('en-US', {
          minimumIntegerDigits: 2,
          useGrouping: false,
        })
      );
  }
}
