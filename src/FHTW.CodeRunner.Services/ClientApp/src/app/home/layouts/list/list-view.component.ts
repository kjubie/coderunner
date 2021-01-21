import { Component, EventEmitter, Input, Output } from "@angular/core";
import { ExerciseHome } from "src/app/data-objects/exercise-home";

@Component({
    selector: 'list-view',
    templateUrl: './list-view.component.html',
    styleUrls: ['../../home.component.css']
})
export class ListViewComponent {

    @Input() exerciseList: ExerciseHome[];
    @Output() exportExerciseEvent = new EventEmitter<number>();
    @Output() addExerciseToCollectionEvent = new EventEmitter<number>();

    exportExercise(idx: number) {
        this.exportExerciseEvent.emit(idx);
    }

    addExerciseToCollection(idx: number) {
        this.addExerciseToCollectionEvent.emit(idx);
    }
}