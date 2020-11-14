import { TestCase } from "./test-case";

export class TestSuit {
    constructor() {
        this.testCaseList = [];
    }

    questionType: string;
    prefill: string;
    solution: string;
    complexity: number;
    testCaseList: TestCase[];
}