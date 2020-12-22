import { TestCase } from "./test-case";

export class TestSuit {
    constructor() {
        this.testCaseList = [];
    }

    id: number;
    questionType: string;
    templateDebugFlag: boolean;
    testOnSaveFlag: boolean;
    globalExtraParam: string;
    runtimeData: string;
    templateParam: string;
    templateParamliftFlag: boolean;
    twigAllFlag: boolean;
    testCaseList: TestCase[];
    
    //prefill: string;
    //solution: string;
    //complexity: number;
}