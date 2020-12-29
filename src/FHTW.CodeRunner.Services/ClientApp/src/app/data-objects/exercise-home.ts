import { Author } from "./author";
import { ProgrammingLanguage } from "./programming-language";
import { Tag } from "./tag";
import { WrittenLanguage } from "./written-language";

export class ExerciseHome {

    constructor() {
        this.versionList = [];
        this.tagList = [];
        this.writtenLanguageList = [];
        this.programmingLanguageList = [];
    }

    id: number;
    title: string;
    created: string;
    user: Author;
    versionList: number[];
    tagList: Tag[];
    writtenLanguageList: WrittenLanguage[];
    programmingLanguageList: ProgrammingLanguage[];
}