import { Author } from "../author";
import { ExerciseLanguage } from "./exercise-language";

export class ExerciseVersion {
    constructor() {
        this.id = 0;
        this.fkUser = new Author();
        this.exerciseLanguage = [];
    }

    id: number;
    versionNumber: number;
    creatorRating: number;
    creatorDifficulty: number;
    lastModified: string;
    validState: number;
    fkUser: Author;
    exerciseLanguage: ExerciseLanguage[];
}