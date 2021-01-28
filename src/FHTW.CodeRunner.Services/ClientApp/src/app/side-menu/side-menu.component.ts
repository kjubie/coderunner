import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { TestCase } from "../data-objects/create-exercise/test-case";
import { ProgrammingLanguage } from "../data-objects/programming-language";
import { WrittenLanguage } from "../data-objects/written-language";

@Component({
    selector: 'side-menu',
    templateUrl: './side-menu.component.html',
    styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent implements OnInit {

    @Input() availableLangsW: WrittenLanguage[];
    @Input() availableLangsP: ProgrammingLanguage[];
    @Input() selectedElement: string;
    @Input() writtenLang: WrittenLanguage[];
    @Input() programmingLang: ProgrammingLanguage[];
    @Input() isLangAvailable;
    @Input() isProgrammingLangAvailable;
    @Input() testCases;

    @Output() selectElementEvent = new EventEmitter<string>();
    @Output() addWrittenLangEvent = new EventEmitter<WrittenLanguage>();
    @Output() removeWrittenLangEvent = new EventEmitter<WrittenLanguage>();
    @Output() addProgrammingLangEvent = new EventEmitter<ProgrammingLanguage>();
    @Output() removeProgrammingLangEvent = new EventEmitter<ProgrammingLanguage>();
    @Output() addTestCaseEvent = new EventEmitter<TestCase>();
    @Output() removeTestCaseEvent = new EventEmitter<number>();

    showHeadList = true;
    showLanguageList = true;
    showBodyList = true;

    ngOnInit() {
        if (this.testCases == undefined) {
            this.testCases = [];
        }
    }

    addLanguage(lang: WrittenLanguage) {
        if (this.availableLangsW.indexOf(lang) != -1) {
            let idx = this.availableLangsW.indexOf(lang);
            this.availableLangsW.splice(idx, 1);
            if (this.availableLangsW.length == 0) {
                this.isLangAvailable = false;
            }
            this.writtenLang.push(lang);
            this.addWrittenLangEvent.emit(lang);
        }
    }

    addProgrammingLanguage(lang: ProgrammingLanguage) {
        if (this.availableLangsP.indexOf(lang) != -1) {
            let idx = this.availableLangsP.indexOf(lang);
            this.availableLangsP.splice(idx, 1);
            if (this.availableLangsP.length == 0) {
                this.isProgrammingLangAvailable = false;
            }
            this.testCases.push(1);
            this.programmingLang.push(lang);
            this.addProgrammingLangEvent.emit(lang);
        }
    }

    addTestCase(test: TestCase) {
        this.addTestCaseEvent.emit(test);
    }

    removeTestCase(idx: number) {
        this.removeTestCaseEvent.emit(idx);
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
            this.removeWrittenLangEvent.emit(lang);
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
            this.removeProgrammingLangEvent.emit(lang);
        }
    }
}