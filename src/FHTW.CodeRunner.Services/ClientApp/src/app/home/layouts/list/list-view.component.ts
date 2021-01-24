import { Component, EventEmitter, Input, Output } from "@angular/core";
import { CollectionHome } from "src/app/data-objects/collection-home";
import { ExerciseHome } from "src/app/data-objects/exercise-home";

@Component({
    selector: 'list-view',
    templateUrl: './list-view.component.html',
    styleUrls: ['../../home.component.css']
})
export class ListViewComponent {

    @Input() exerciseList: ExerciseHome[];
    @Input() collectionList: CollectionHome[];
    @Input() showExercises: boolean;
    @Output() exportExerciseEvent = new EventEmitter<number>();
    @Output() exportCollectionEvent = new EventEmitter<number>();
    @Output() addExerciseToCollectionEvent = new EventEmitter<number>();

    exportExercise(idx: number) {
        this.exportExerciseEvent.emit(idx);
    }

    exportCollection(idx: number) {
        this.exportCollectionEvent.emit(idx);
    }

    addExerciseToCollection(idx: number) {
        this.addExerciseToCollectionEvent.emit(idx);
    }
}