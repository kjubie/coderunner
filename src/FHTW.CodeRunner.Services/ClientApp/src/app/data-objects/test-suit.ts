import { TestCase } from "./test-case";

export class TestSuit {
    constructor() {
        this.testCases = TestCase[0];
    }

    questionType: string;
    prefill: string;
    solution: string;
    complexity: number;
    testCases: TestCase[];
}