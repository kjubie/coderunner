import { Component, EventEmitter, Input, Output } from "@angular/core";
import { Exercise } from "src/app/data-objects/exercise";

@Component({
    selector: 'programming-tab',
    templateUrl: './programming-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class ProgrammingTabComponent {

    @Input() exercise: Exercise;
    @Output() newTabSelectedEvent = new EventEmitter<string>();

    setTab(tab: string) {
        this.newTabSelectedEvent.emit(tab);
    }
}