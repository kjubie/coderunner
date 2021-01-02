import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { ProgrammingLanguage } from "src/app/data-objects/programming-language";

@Component({
    selector: 'programming-language-element',
    templateUrl: './programming-language-element.component.html',
    styleUrls: ['../../side-menu.component.css']
})
export class ProgrammingLanguageElementComponent implements OnInit {
    
    @Input() lang;
    @Input() writtenLang;
    @Input() idx;
    @Input() selectedElement;

    @Output() selectElementEvent = new EventEmitter<string>();
    @Output() removePLangEvent = new EventEmitter<ProgrammingLanguage>();

    programmingLang;
    testCases = [];
    showProgrammingList = true;
    showTestSuitList = true;
    showWrittenLanguageList = true;

    ngOnInit() {
        this.testCases.push('Test 1');
    }

    addTestCase() {
        var index = this.testCases.length + 1;
        var testCase = 'Test ' + index.toString();
        this.testCases.push(testCase);
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
        else if (listName === 'writtenLanguageList') {
            this.showWrittenLanguageList = !this.showWrittenLanguageList;
            if (this.showWrittenLanguageList) {
                document.getElementById('arrowWrittenLanguageList' + idx).classList.remove("right");
                document.getElementById('arrowWrittenLanguageList' + idx).classList.add("down");
            }
            else {
                document.getElementById('arrowWrittenLanguageList' + idx).classList.remove("down");
                document.getElementById('arrowWrittenLanguageList' + idx).classList.add("right");
            }
        }
    }

    setSelectedElement(element: string) {
        this.selectElementEvent.emit(element);
    }

    removePLang(lang: ProgrammingLanguage) {
        this.removePLangEvent.emit(lang);
    }

    removeTestCase(test: string) {
        if (this.testCases.indexOf(test) != -1) {
            let i = this.testCases.indexOf(test);
            this.testCases.splice(i, 1);
        }
    }

    isLastTestCase(index: number) {
        let currentSize = this.testCases.length;
        let currIdx = currentSize -1;
        
        if (currentSize != 1 && currIdx != 0 && currIdx == index) {
            return true;
        }

        return false;
    }
}