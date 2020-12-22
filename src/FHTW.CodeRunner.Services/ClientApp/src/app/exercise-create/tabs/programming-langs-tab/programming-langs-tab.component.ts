import { Component, EventEmitter, Input, Output } from "@angular/core";
import { Exercise } from "src/app/data-objects/create-exercise/exercise";

@Component({
    selector: 'programming-langs-tab',
    templateUrl: './programming-langs-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class ProgrammingLangsTabComponent {

    @Input() exercise: Exercise;
    @Input() languages: string[];
}