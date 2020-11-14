import { User } from "oidc-client";
import { ExerciseHeader } from "./exercise-header";
import { Author } from "./author";
import { Tag } from "./tag";
import { ExerciseVersion } from "./exercise-version";

export class Exercise {
    constructor() {
        this.user = new Author();
        this.exerciseTagList = [];
        this.exerciseVersionList = [];
    }

    title: string;
    created: Date;
    user: Author;
    exerciseTagList: Tag[];
    exerciseVersionList: ExerciseVersion[];
}