import { Tag } from "./tag";

export class CreateExercise {
    fullTitle: string;
    shortTitle: string;
    introduction: string;
    writtenLanguage: string;
    programmingLanguage: string;
    description: string;
    example: string;
    hint: string;
    points: number;
    author: string; // should be read from logged in user -> for testing purpose
    tags: Tag[];
    // metadata: Metadata[];
}