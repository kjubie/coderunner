import { Author } from "../author";
import { ExerciseLanguage } from "./exercise-language";

export class ExerciseVersion {
    constructor() {
        this.user = new Author();
        this.exerciseLanguageList = [];
    }

    versionNumber: number;
    creatorRating: number;
    creatorDifficulty: number;
    lasModified: Date;
    user: Author;
    exerciseLanguageList: ExerciseLanguage[];
}