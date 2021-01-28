import { Author } from "../author";
import { Tag } from "../tag";
import { CollectionLanguage } from "./collection-language";
import { MinimalCollectionExercise } from "./minimal-collection-exercise";

export class ShowCollection {
    constructor() {
        this.id = 0;
        this.user = new Author();
        this.collectionTagList = [];
        this.collectionLanguageList = [];
        this.minimalCollectionExerciseList = [];
    }

    id: number;
    title: string;
    created: Date;
    user: Author;
    collectionLanguageList: CollectionLanguage[];
    collectionTagList: Tag[];
    minimalCollectionExerciseList: MinimalCollectionExercise[];
}