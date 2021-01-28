import { Component, DoCheck, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { TestSuite } from "src/app/data-objects/create-exercise/test-suite";
import { QuestionType } from "src/app/data-objects/question-type";

@Component({
    selector: 'test-suit-tab',
    templateUrl: './test-suit-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class TestSuitTabComponent  {

    @Input() testSuite: TestSuite;
    @Input() questionTypes: QuestionType[];

    @Output() testSuiteChangeEvent = new EventEmitter<TestSuite>();
}