import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
    selector: 'programming-language-element',
    templateUrl: './programming-language-element.component.html',
    styleUrls: ['../../side-menu.component.css']
})
export class ProgrammingLanguageElementComponent {
    @Input() lang;
    @Input() writtenLang;
    @Input() idx;
    @Input() selectedElement;
    @Output() selectElementEvent = new EventEmitter<string>();
    programmingLang;
    testCases = ["Test"]
    showProgrammingList = true;
    showTestSuitList = true;

    addTestCase() {
        this.testCases.push("Test");
    }

    collapseList(listName: string, idx: string) {
        if (listName === 'programmingList') {
            this.showProgrammingList = !this.showProgrammingList;
            if (this.showProgrammingList) {
                document.getElementById('arrowProgrammingList' + idx).classList.remove("right");
                document.getElementById('arrowProgrammingList' + idx).classList.add("down");
            }
            else {
                document.getElementById('arrowProgrammingList' + idx).classList.remove("down");
                document.getElementById('arrowProgrammingList' + idx).classList.add("right");
            }
        }
        else if (listName === 'testSuitList') {
            this.showTestSuitList = !this.showTestSuitList;
            if (this.showTestSuitList) {
                document.getElementById('arrowTestSuitList' + idx).classList.remove("right");
                document.getElementById('arrowTestSuitList' + idx).classList.add("down");
            }
            else {
                document.getElementById('arrowTestSuitList' + idx).classList.remove("down");
                document.getElementById('arrowTestSuitList' + idx).classList.add("right");
            }
        }
    }

    setSelectedElement(element: string) {
        this.selectElementEvent.emit(element);
    }
}