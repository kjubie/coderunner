import { ExerciseBody } from "./exercise-body";

export class ExerciseHeader {
    constructor() {
        this.body = new ExerciseBody();
    }

    writtenLanguage: string;
    fullTitle: string;
    shortTitle: string;
    introduction: string;
    body: ExerciseBody;
}