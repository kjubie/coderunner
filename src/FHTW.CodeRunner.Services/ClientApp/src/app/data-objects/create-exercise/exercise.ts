import { User } from "oidc-client";
import { ExerciseHeader } from "./exercise-header";
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
    created: string;
    fkUser: Author;
    exerciseTag: Tag[];
    exerciseVersion: ExerciseVersion[];
}