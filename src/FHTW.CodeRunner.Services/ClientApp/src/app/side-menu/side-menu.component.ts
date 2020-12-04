import { Component } from "@angular/core";

@Component({
    selector: 'side-menu',
    templateUrl: './side-menu.component.html',
    styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent {
    writtenLang = ["German"];
    programmingLang = [];
    testCases = ["Test"]

    addLanguage(lang: string) {
        this.writtenLang.push(lang);
    }

    addProgrammingLanguage(lang: string) {
        this.programmingLang.push(lang);
    }

    addTestCase() {
        this.testCases.push("Test");
    }
}