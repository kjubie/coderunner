import { ExerciseBody } from "./exercise-body";
import { ExerciseHeader } from "./exercise-header";
import { WrittenLanguage } from "../written-language";

export class ExerciseLanguage {
    constructor() {
        this.exerciseHeader = new ExerciseHeader();
        this.writtenLanguage = new WrittenLanguage();
        this.exerciseBody = new ExerciseBody();
    }

    id: number;
    exerciseHeader: ExerciseHeader;
    writtenLanguage: WrittenLanguage;
    exerciseBody: ExerciseBody;

}