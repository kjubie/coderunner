import { Component, Input } from "@angular/core";
import { Exercise } from "src/app/data-objects/create-exercise/exercise";

@Component({
    selector: 'general-tab',
    templateUrl: './general-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class GeneralTabComponent {

    @Input() exercise: Exercise;
}