import { Component, Input } from "@angular/core";
import { ExerciseHome } from "src/app/data-objects/exercise-home";

@Component({
    selector: 'list-view',
    templateUrl: './list-view.component.html',
    styleUrls: ['../../home.component.css']
})
export class ListViewComponent {

    @Input() exerciseList: ExerciseHome[];
}