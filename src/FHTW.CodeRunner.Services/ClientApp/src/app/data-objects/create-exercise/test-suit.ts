import { TestCase } from "./test-case";

export class TestSuit {
    constructor() {
        this.testCaseList = [];
    }

    questionType: string;
    prefill: string;
    solution: string;
    complexity: number;
    templateDebugFlag: boolean;
    testOnSaveFlag: boolean;
    globalExtra: string;
    runtimeData: string;
    templateParam: string;
    liftParamFlag: boolean;
    twigAllFlag: boolean;
    testCaseList: TestCase[];
}