import { Component, EventEmitter, Input, Output } from "@angular/core";
import { Exercise } from "src/app/data-objects/create-exercise/exercise";

@Component({
    selector: 'testcase-tab',
    templateUrl: './testcase-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class TestCaseTabComponent {

    @Input() exercise: Exercise;
    @Output() newTabSelectedEvent = new EventEmitter<string>();

    setTab(tab: string) {
        this.newTabSelectedEvent.emit(tab);
    }
}