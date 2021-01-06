import { ProgrammingLanguage } from "../programming-language";
import { TestSuite } from "./test-suite";

export class ExerciseBody {

    constructor() {
        this.id = 0;
        this.fkProgrammingLanguage = new ProgrammingLanguage();
        this.fkTestSuite = new TestSuite();
    }

    id: number;
    description: string;
    hint: string;
    fieldLines: number;
    gradingFlag: boolean;
    subtractSystem: string;
    obtainablePoints: number;
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
    fkProgrammingLanguage: ProgrammingLanguage;
    fkTestSuite: TestSuite;
}