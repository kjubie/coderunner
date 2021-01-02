import { Component, Input, OnInit } from "@angular/core";
import { TestSuit } from "src/app/data-objects/create-exercise/test-suit";
import { QuestionType } from "src/app/data-objects/question-type";

@Component({
    selector: 'test-suit-tab',
    templateUrl: './test-suit-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class TestSuitTabComponent implements OnInit {

    @Input() testSuit: TestSuit;
    @Input() questionTypes: QuestionType[];

    ngOnInit() {
        this.testSuit.fkQuestionType = new QuestionType();
    }
}