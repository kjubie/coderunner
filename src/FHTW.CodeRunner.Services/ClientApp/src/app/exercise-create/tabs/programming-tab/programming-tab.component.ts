import { Component, DoCheck, EventEmitter, Input, Output } from "@angular/core";
import { ExerciseBody } from "src/app/data-objects/create-exercise/exercise-body";

@Component({
    selector: 'programming-tab',
    templateUrl: './programming-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class ProgrammingTabComponent {

    @Input() exerciseBody: ExerciseBody;

    @Output() bodyChangeEvent = new EventEmitter<ExerciseBody>();
}