import { Component, Input } from "@angular/core";
import { Exercise } from "src/app/data-objects/exercise";

@Component({
    selector: 'list-view',
    templateUrl: './list-view.component.html',
    styleUrls: ['../../home.component.css']
})
export class ListViewComponent {

    @Input() exerciseList: Exercise[];
}