import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { ProgrammingLanguage } from "../data-objects/programming-language";
import { WrittenLanguage } from "../data-objects/written-language";

@Component({
    selector: 'side-menu',
    templateUrl: './side-menu.component.html',
    styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent {
    @Input() availableLangsW: WrittenLanguage[];
    @Input() availableLangsP: ProgrammingLanguage[];
    @Input() selectedElement: string;
    @Output() selectElementEvent = new EventEmitter<string>();
    @Output() addWrittenLangEvent = new EventEmitter<string>();
    @Output() addProgrammingLangEvent = new EventEmitter<string>();
    writtenLang = [{id: 1, name: "Engish"}];
    programmingLang: ProgrammingLanguage[] = [];
    testCases = ["Test"];
    showHeadList = true;
    showLanguageList = true;
    showBodyList = true;
    isLangAvailable = true;
    isProgrammingLangAvailable = true;

    addLanguage(lang: WrittenLanguage) {
        if (this.availableLangsW.indexOf(lang) != -1) {
            let idx = this.availableLangsW.indexOf(lang);
            this.availableLangsW.splice(idx, 1);
            if (this.availableLangsW.length == 0) {
                this.isLangAvailable = false;
            }
            this.writtenLang.push(lang);
            this.addWrittenLangEvent.emit(lang.name);
        }
    }

    addProgrammingLanguage(lang: ProgrammingLanguage) {
        if (this.availableLangsP.indexOf(lang) != -1) {
            let idx = this.availableLangsP.indexOf(lang);
            this.availableLangsP.splice(idx, 1);
            if (this.availableLangsP.length == 0) {
                this.isProgrammingLangAvailable = false;
            }
            this.programmingLang.push(lang);
            this.addProgrammingLangEvent.emit(lang.name);
        }
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
        else if (listName === 'languageList') {
            this.showLanguageList = !this.showLanguageList;
            if (this.showLanguageList) {
                document.getElementById('arrowLanguageList').classList.remove("right");
                document.getElementById('arrowLanguageList').classList.add("down");
            }
            else {
                document.getElementById('arrowLanguageList').classList.remove("down");
                document.getElementById('arrowLanguageList').classList.add("right");
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

    removeWLang(lang: WrittenLanguage) {
        if (this.writtenLang.indexOf(lang) != -1) {
            let idx = this.writtenLang.indexOf(lang);
            this.writtenLang.splice(idx, 1);
            this.availableLangsW.push(lang);
            if (!this.isLangAvailable) {
                this.isLangAvailable = true;
            }
        }
    }

    removePLang(lang: ProgrammingLanguage) {
        if (this.programmingLang.indexOf(lang) != -1) {
            let idx = this.programmingLang.indexOf(lang);
            this.programmingLang.splice(idx, 1);
            this.availableLangsP.push(lang);
            if (!this.isProgrammingLangAvailable) {
                this.isProgrammingLangAvailable = true;
            }
        }
    }
}