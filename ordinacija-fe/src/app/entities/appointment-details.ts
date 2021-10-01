import { TimeSpan } from "./time-span";

export class AppointmentDetails {
    id: number;
    dateStart: Date;
    dateEnd: Date;
    duration: TimeSpan;

    constructor(id: number, dateStart: Date, dateEnd: Date, duration: TimeSpan) {
        this.id = id;
        this.dateStart = dateStart;
        this.dateEnd = dateEnd;
        this.duration = duration;
    }
}
