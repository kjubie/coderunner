import { ProgrammingLanguage } from "../programming-language";
import { TestSuit } from "./test-suit";

export class ExerciseBody {

    id: number;
    description: string;
    hint: string;
    fieldLines: number;
    gradingFlag: boolean;
    subtractSystem: string;
    optainablePoints: number;
    idNum: number;
    solution: string;
    prefill: string;
    feedback: string;
    allowFiles: number;
    filesRequired: number;
    filesRegex: string;
    filesDescription: string;
    filesSize: number;
    
    minAllowedFiles: number;
    maxAllowedFiles: number;
    minRequiredFiles: number;
    maxRequiredFiles: number;
    example: string;
    programmingLanguage: ProgrammingLanguage;
    testSuit: TestSuit;
}