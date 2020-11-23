import { ProgrammingLanguage } from "../programming-language";
import { TestSuit } from "./test-suit";

export class ExerciseBody {
    constructor() {
        this.programmingLanguage = new ProgrammingLanguage();
        this.testSuit = new TestSuit();
    }

    description: string;
    example: string;
    hint: string;
    programmingLanguage: ProgrammingLanguage;
    testSuit: TestSuit;
}