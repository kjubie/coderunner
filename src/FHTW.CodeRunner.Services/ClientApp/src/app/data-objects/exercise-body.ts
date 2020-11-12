import { Tag } from "./tag";
import { TestSuit } from "./test-suit";

export class ExerciseBody {
    constructor() {
        this.tags = Tag[0];
        this.testSuit = new TestSuit();
    }

    programmingLanguage: string;
    description: string;
    example: string;
    hint: string;
    tags: Tag[];
    testSuit: TestSuit;
}