import { Author } from "../author";
import { Tag } from "../tag";
import { ExerciseVersion } from "./exercise-version";

export class Exercise {
    constructor() {
        this.id = 0;
        this.fkUser = new Author();
        this.exerciseTag = [];
        this.exerciseVersion = [];
    }

    id: number;
    title: string;
    created: Date;
    fkUser: Author;
    exerciseTag: Tag[];
    exerciseVersion: ExerciseVersion[];
}