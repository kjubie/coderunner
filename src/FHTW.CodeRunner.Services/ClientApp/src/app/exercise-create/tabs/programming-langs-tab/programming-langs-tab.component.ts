import { Component, Input } from "@angular/core";
import { ExerciseBody } from "src/app/data-objects/create-exercise/exercise-body";

@Component({
    selector: 'programming-langs-tab',
    templateUrl: './programming-langs-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class ProgrammingLangsTabComponent {

    @Input() exerciseBody: ExerciseBody;
    @Input() writtenLang: string;

    hidePreview() { console.log('test'); }
}