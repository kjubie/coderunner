import { ExerciseBody } from "./exercise-body";
import { ExerciseHeader } from "./exercise-header";
import { WrittenLanguage } from "../written-language";

export class ExerciseLanguage {
    constructor() {
        this.id = 0;
        this.exerciseHeader = new ExerciseHeader();
        this.writtenLanguage = new WrittenLanguage();
        this.exerciseBody = [];
    }

    id: number;
    exerciseHeader: ExerciseHeader;
    writtenLanguage: WrittenLanguage;
    exerciseBody: ExerciseBody[];

}