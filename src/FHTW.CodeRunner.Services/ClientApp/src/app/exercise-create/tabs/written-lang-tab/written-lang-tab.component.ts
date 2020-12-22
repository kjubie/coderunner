import { Component, Input } from "@angular/core";
import { ExerciseLanguage } from "src/app/data-objects/create-exercise/exercise-language";

@Component({
    selector: 'written-lang-tab',
    templateUrl: './written-lang-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class WrittenLangTabComponent {

    @Input() exerciseLanguage: ExerciseLanguage;
}