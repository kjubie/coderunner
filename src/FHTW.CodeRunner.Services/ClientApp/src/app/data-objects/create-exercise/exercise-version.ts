import { Author } from "../author";
import { ExerciseLanguage } from "./exercise-language";

export class ExerciseVersion {
    constructor() {
        this.user = new Author();
        this.exerciseLanguageList = [];
    }

    id: number;
    versionNumber: number;
    creatorRating: number;
    creatorDifficulty: number;
    lastModified: Date;
    user: Author;
    exerciseLanguageList: ExerciseLanguage[];
}