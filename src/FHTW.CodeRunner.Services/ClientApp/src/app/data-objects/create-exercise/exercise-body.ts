import { ProgrammingLanguage } from "../programming-language";
import { TestSuit } from "./test-suit";

export class ExerciseBody {
    constructor() {
        this.programmingLanguage = new ProgrammingLanguage();
        this.testSuit = new TestSuit();
    }

    minAllowedFiles: number;
    maxAllowedFiles: number;
    minRequiredFiles: number;
    maxRequiredFiles: number;
    fieldLines: number;
    gradingFlag: boolean;
    subtractSystem: string;
    optainablePoints: number;
    solution: string;
    prefill: string;
    feedback: string;
    allowFiles: number;
    filesRequired: number;
    filesRegex: string;
    filesDescription: string;
    filesSize: number;
    description: string;
    example: string;
    hint: string;
    programmingLanguage: ProgrammingLanguage;
    testSuit: TestSuit;
}