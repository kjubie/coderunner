import { Author } from "../author";
import { CollectionTag } from "./collection-tag";
import { CollectionLanguage } from "./collection-language";
import { ExerciseHome } from "../exercise-home";

export class ShowCollection {
    constructor() {
        this.id = 0;
        this.user = new Author();
        this.collectionTagList = [];
        this.collectionLanguageList = [];
        this.collectionExerciseHomeList = [];
    }

    id: number;
    title: string;
    created: Date;
    user: Author;
    collectionLanguageList: CollectionLanguage[];
    collectionTagList: CollectionTag[];
    collectionExerciseHomeList: ExerciseHome[];
}