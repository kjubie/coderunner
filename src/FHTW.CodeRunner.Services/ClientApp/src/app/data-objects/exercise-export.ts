import { Author } from "./author";
import { ProgrammingLanguage } from "./programming-language";
import { Tag } from "./tag";
import { WrittenLanguage } from "./written-language";

export class ExerciseExport {
    
    constructor() {
        this.tagList = [];
        this.writtenLanguage = new WrittenLanguage;
        this.programmingLanguage = new ProgrammingLanguage;
    }

    id: number;
    title: string;
    created: string;
    user: Author;
    tagList: Tag[];
    writtenLanguage: WrittenLanguage;
    programmingLanguage: ProgrammingLanguage;
}