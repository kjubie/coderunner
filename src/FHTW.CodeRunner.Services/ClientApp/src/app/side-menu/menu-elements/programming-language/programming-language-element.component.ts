import { Component, Input } from "@angular/core";

@Component({
    selector: 'programming-language-element',
    templateUrl: './programming-language-element.component.html',
    styleUrls: ['../../side-menu.component.css']
})
export class ProgrammingLanguageElementComponent {
    @Input() lang;
    @Input() writtenLang;
    programmingLang;
    testCases = ["Test"]

    addTestCase() {
        this.testCases.push("Test");
    }
}