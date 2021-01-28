import { Author } from "../author";

export class MinimalCollectionExercise {
    id: number;
    title: string;
    created: Date;
    user: Author;
    writtenLanguage: string;
    programmingLanguage: string;
    version: number;
}