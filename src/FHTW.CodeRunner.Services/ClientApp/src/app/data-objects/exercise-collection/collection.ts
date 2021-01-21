import { Author } from "../author";
import { CollectionExercise } from "./collection-exercise";
import { CollectionTag } from "./collection-tag";
import { CollectionLanguage } from "./collection-language";

export class Collection {
    constructor() {
        this.id = 0;
        this.collectionTagList = [];
        this.collectionLanguageList = [];
        this.collectionExerciseList = [];
    }

    id: number;
    title: string;
    created: Date;
    user: Author;
    collectionLanguageList: CollectionLanguage[];
    collectionTagList: CollectionTag[];
    collectionExerciseList: CollectionExercise[];
}