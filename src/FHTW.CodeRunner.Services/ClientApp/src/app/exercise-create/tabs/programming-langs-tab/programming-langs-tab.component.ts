import { Component, DoCheck, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { EditorInstance, EditorOption } from "angular-markdown-editor";
import { MarkdownService } from "ngx-markdown";
import { ExerciseBody } from "src/app/data-objects/create-exercise/exercise-body";

@Component({
    selector: 'programming-langs-tab',
    templateUrl: './programming-langs-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class ProgrammingLangsTabComponent implements OnInit {

    @Input() exerciseBody: ExerciseBody;
    @Input() writtenLang: string;

    @Output() bodyChangeEvent = new EventEmitter<ExerciseBody>();

    bsEditorInstance: EditorInstance;
    editorOptions: EditorOption;

    constructor(private markdownService: MarkdownService) {}

    ngOnInit() {
        this.editorOptions = {
            autofocus: false,
            iconlibrary: 'fa',
            savable: false,
            onFullscreenExit: (e) => this.hidePreview(e),
            onShow: (e) => this.bsEditorInstance = e,
            parser: (val) => this.parse(val)
        };
    }

    /** highlight all code found, needs to be wrapped in timer to work properly */
    highlight() {
        setTimeout(() => {
        this.markdownService.highlight();
        });
    }

    hidePreview(e) {
        if (this.bsEditorInstance && this.bsEditorInstance.hidePreview) {
        this.bsEditorInstance.hidePreview();
        }
    }

    showFullScreen(isFullScreen: boolean) {
        if (this.bsEditorInstance && this.bsEditorInstance.setFullscreen) {
        this.bsEditorInstance.showPreview();
        this.bsEditorInstance.setFullscreen(isFullScreen);
        }
    }

    parse(inputValue: string) {
        const markedOutput = this.markdownService.compile(inputValue.trim());
        this.highlight();

        return markedOutput;
    }
}