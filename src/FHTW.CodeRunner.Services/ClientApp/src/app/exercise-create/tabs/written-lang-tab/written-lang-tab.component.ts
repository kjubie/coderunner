import { Component, EventEmitter, Input, Output } from "@angular/core";
import { Exercise } from "src/app/data-objects/create-exercise/exercise";

@Component({
    selector: 'written-lang-tab',
    templateUrl: './written-lang-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class WrittenLangTabComponent {

    @Input() exercise: Exercise;
    @Input() idx: number;
}