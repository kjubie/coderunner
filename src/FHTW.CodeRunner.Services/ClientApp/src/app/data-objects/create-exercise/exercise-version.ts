import { Author } from "../author";
import { ExerciseLanguage } from "./exercise-language";

export class ExerciseVersion {
    constructor() {
        this.id = 0;
        this.user = new Author();
        this.exerciseLanguageList = [];
    }

    id: number;
    versionNumber: number;
    creatorRating: number;
    creatorDifficulty: number;
    lastModified: Date;
    validState: number;
    user: Author;
    exerciseLanguageList: ExerciseLanguage[];
}