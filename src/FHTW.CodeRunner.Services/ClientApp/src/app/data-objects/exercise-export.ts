import { Author } from "./author";
import { ProgrammingLanguage } from "./programming-language";
import { Tag } from "./tag";
import { WrittenLanguage } from "./written-language";

export class ExerciseExport {
    
    constructor() {
        this.tagList = [];
    }

    id: number;
    version: number;
    tagList: Tag[];
    writtenLanguage: string;
    programmingLanguage: string;
}