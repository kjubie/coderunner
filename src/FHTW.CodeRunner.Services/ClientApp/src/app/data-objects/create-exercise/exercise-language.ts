import { ExerciseBody } from "./exercise-body";
import { ExerciseHeader } from "./exercise-header";
import { WrittenLanguage } from "../written-language";

export class ExerciseLanguage {
    constructor() {
        this.id = 0;
        this.fkExerciseHeader = new ExerciseHeader();
        this.fkWrittenLanguage = new WrittenLanguage();
        this.exerciseBody = [];
    }

    id: number;
    fkExerciseHeader: ExerciseHeader;
    fkWrittenLanguage: WrittenLanguage;
    exerciseBody: ExerciseBody[];

}