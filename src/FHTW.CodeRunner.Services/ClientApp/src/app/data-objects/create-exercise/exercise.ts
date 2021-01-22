import { Author } from "../author";
import { ExerciseTag } from "./exercise-tags";
import { ExerciseVersion } from "./exercise-version";

export class Exercise {
    constructor() {
        this.id = 0;
        this.user = new Author();
        this.exerciseTagList = [];
        this.exerciseVersionList = [];
    }

    id: number;
    title: string;
    created: Date;
    user: Author;
    exerciseTagList: ExerciseTag[];
    exerciseVersionList: ExerciseVersion[];
}