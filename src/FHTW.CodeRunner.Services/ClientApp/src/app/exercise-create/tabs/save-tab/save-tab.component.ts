import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Exercise } from 'src/app/data-objects/create-exercise/exercise';

@Component({
    selector: 'save-tab',
    templateUrl: './save-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class SaveTabComponent {

    @Input() exercise: Exercise;
    @Output() saveExerciseEvent = new EventEmitter<Exercise>();

    saveExercise() {
        this.saveExerciseEvent.emit(this.exercise);
    }
}