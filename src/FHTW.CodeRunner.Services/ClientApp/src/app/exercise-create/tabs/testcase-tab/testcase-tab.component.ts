import { Component, Input } from "@angular/core";
import { ExerciseBody } from "src/app/data-objects/create-exercise/exercise-body";
import { TestCase } from "src/app/data-objects/create-exercise/test-case";

@Component({
    selector: 'testcase-tab',
    templateUrl: './testcase-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class TestCaseTabComponent {

    @Input() exerciseBody: ExerciseBody;
    @Input() testCase: TestCase;
    @Input() testCaseIdx: number;
}