import { Author } from "./author";
import { ProgrammingLanguage } from "./programming-language";
import { Tag } from "./tag";
import { WrittenLanguage } from "./written-language";

export class ExerciseExport {
    
    constructor() {}

    id: number;
    version: number;
    writtenLanguage: string;
    programmingLanguage: string;
}