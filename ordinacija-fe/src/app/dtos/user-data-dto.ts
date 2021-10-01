export class UserDataDto {
    email: string;
    jmbg: string;

    constructor(email: string, jmbg: string) {
        this.email = email;
        this.jmbg = jmbg;
    }
}
