import { Component, Input } from "@angular/core";
import { ExerciseBody } from "src/app/data-objects/create-exercise/exercise-body";
import { QuestionType } from "src/app/data-objects/question-type";

@Component({
    selector: 'test-suit-tab',
    templateUrl: './test-suit-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class TestSuitTabComponent {

    @Input() exerciseBody: ExerciseBody;
    @Input() questionTypes: QuestionType[];
}