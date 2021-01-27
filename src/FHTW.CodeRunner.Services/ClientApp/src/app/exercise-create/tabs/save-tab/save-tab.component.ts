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

    questionTypes = [];

    displayTypes = [
        { key: 'Show', value: 'SHOW' },
        { key: 'Hide', value: 'HIDE' },
        { key: 'Hide if fail', value: 'HIDE_IF_FAIL' },
        { key: 'Hide if succeed', value: 'HIDE_IF_SUCCEED' }
    ];

    saveExercise() {
        this.saveExerciseEvent.emit(this.exercise);
    }

    test() {
        console.log(this.exercise);
    }
}