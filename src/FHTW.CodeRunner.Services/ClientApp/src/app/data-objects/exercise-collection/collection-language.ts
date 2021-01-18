import { WrittenLanguage } from "../written-language";

export class CollectionLanguage {
    constructor() {
        this.id = 0;
    }

    id: number;
    fullTitle: string;
    shortTitle: string;
    introduction: string;
    writtenLanguage: WrittenLanguage;
}