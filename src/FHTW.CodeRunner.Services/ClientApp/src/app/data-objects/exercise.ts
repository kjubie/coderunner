import { User } from "oidc-client";
import { ExerciseHeader } from "./exercise-header";
import { Author } from "./author";

export class Exercise {
    constructor() {
        this.user = new Author();
        this.header = new ExerciseHeader();
    }

    title: string;
    created: Date;
    user: Author;
    header: ExerciseHeader;
}