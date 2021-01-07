import { QuestionType } from "../question-type";
import { TestCase } from "./test-case";

export class TestSuite {
    constructor() {
        this.id = 0;
        this.testCaseList = [new TestCase()];
        this.questionType = new QuestionType();
    }

    id: number;
    questionType: QuestionType;
    templateDebugFlag: boolean;
    testOnSaveFlag: boolean;
    globalExtraParam: string;
    runtimeData: string;
    preCheck: number;
    generalFeedbackDisplay: number;
    testCaseList: TestCase[];
    
    //prefill: string;
    //solution: string;
    //complexity: number;
}