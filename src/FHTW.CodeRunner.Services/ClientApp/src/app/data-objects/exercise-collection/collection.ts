import { Exercise } from "../create-exercise/exercise";
import { Author } from "../author";
import { CollectionTag } from "./collection-tag";
import { CollectionLanguage } from "./collection-language";

export class ExerciseCollection {
    constructor() {
        this.id = 0;
    }

    id: number;
    title: string;
    created: Date;
    user: Author;
    collectionLanguageList: CollectionLanguage[];
    collectionTagList: CollectionTag[];
    collectionExerciseList: Exercise[];
    
}