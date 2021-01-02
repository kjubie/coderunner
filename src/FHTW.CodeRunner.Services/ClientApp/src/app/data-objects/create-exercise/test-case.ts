export class TestCase {
    constructor() {
        this.id = 0;
    }
    id: number;
    orderUsed: number;
    testCode: string;
    standardInput: string;
    expectedOutput: string;
    additionalData: string;
    points: number;
    useAsExampleFlag: boolean;
    hideOnFailFlag: boolean;
    displayType: string;
}