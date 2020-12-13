import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
    selector: 'side-menu',
    templateUrl: './side-menu.component.html',
    styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent {
    @Input() selectedElement: string;
    @Output() selectElementEvent = new EventEmitter<string>();
    @Output() addWrittenLangEvent = new EventEmitter<string>();
    @Output() addProgrammingLangEvent = new EventEmitter<string>();
    writtenLang = ["German"];
    programmingLang = [];
    testCases = ["Test"];
    showHeadList = true;
    showBodyList = true;
    availableLangs = ["English", "French", "Spanish"];
    isLangAvailable = true;

    addLanguage(lang: string) {
        if (this.availableLangs.indexOf(lang) != -1) {
            let idx = this.availableLangs.indexOf(lang);
            this.availableLangs.splice(idx, 1);
            if (this.availableLangs.length == 0) {
                this.isLangAvailable = false;
            }
            this.writtenLang.push(lang);
            this.addWrittenLangEvent.emit(lang);
        }
    }

    addProgrammingLanguage(lang: string) {
        this.programmingLang.push(lang);
        this.addProgrammingLangEvent.emit(lang);
    }

    addTestCase() {
        this.testCases.push("Test");
    }

    collapseList(listName: string) {
        if (listName === 'headList') {
            this.showHeadList = !this.showHeadList;
            if (this.showHeadList) {
                document.getElementById('arrowHeadList').classList.remove("right");
                document.getElementById('arrowHeadList').classList.add("down");
            }
            else {
                document.getElementById('arrowHeadList').classList.remove("down");
                document.getElementById('arrowHeadList').classList.add("right");
            }
        }
        else if (listName === 'bodyList') {
            this.showBodyList = !this.showBodyList;
            if (this.showBodyList) {
                document.getElementById('arrowBodyList').classList.remove("right");
                document.getElementById('arrowBodyList').classList.add("down");
            }
            else {
                document.getElementById('arrowBodyList').classList.remove("down");
                document.getElementById('arrowBodyList').classList.add("right");
            }
        }
    }

    setSelectedElement(element: string) {
        this.selectElementEvent.emit(element);
    }
}