import { Author } from "./author";
import { Tag } from "./tag";
import { WrittenLanguage } from "./written-language";

export class CollectionHome {

    constructor() {}

    id: number;
    title: string;
    created: string;
    exerciseCount: number;
    user: Author;
    writtenLanguageList: WrittenLanguage[];
    tagList: Tag[];
}