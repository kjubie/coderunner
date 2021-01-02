import { QuestionType } from "../question-type";
import { TestCase } from "./test-case";

export class TestSuit {
    constructor() {
        this.id = 0;
        this.testCase = [];
    }

    id: number;
    fkQuestionType: QuestionType;
    templateDebugFlag: boolean;
    testOnSaveFlag: boolean;
    globalExtraParam: string;
    runtimeData: string;
    preCheck: number;
    generalFeedbackDisplay: number;
    testCase: TestCase[];
    
    //prefill: string;
    //solution: string;
    //complexity: number;
}