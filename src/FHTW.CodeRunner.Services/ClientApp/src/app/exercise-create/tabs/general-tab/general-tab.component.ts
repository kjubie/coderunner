import { Component, Input, Output, EventEmitter, DoCheck } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { ModalDismissReasons, NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Exercise } from "src/app/data-objects/create-exercise/exercise";
import { ExerciseTag } from "src/app/data-objects/create-exercise/exercise-tags";
import { Tag } from "src/app/data-objects/tag";

@Component({
    selector: 'general-tab',
    templateUrl: './general-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class GeneralTabComponent {

    @Input() exercise: Exercise;
    @Input() existingTags: Tag[];

    @Output() exerciseChangeEvent = new EventEmitter<Exercise>();

    newTagForm;
    existingTagForm;

    constructor(private modalService: NgbModal, private formBuilder: FormBuilder) {
        this.newTagForm = formBuilder.group({
            tagName: ''
        });

        this.existingTagForm = formBuilder.group({
            tag: new Tag()
        });
    }

    createNewTag(modalContent) {
        // open Modal for new Tags
        this.modalService.open(modalContent, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
            console.log('Closed with ' + result);
        }, (reason) => {
            console.log('Dismissed ' + this.getDismissReason(reason));
        });

        this.newTagForm.reset();
    }

    addNewTag(formData) {
        let tag = new Tag();
        tag.id = 0;
        tag.name = formData.tagName;

        let exerciseTag = new ExerciseTag();
        exerciseTag.tag = tag;

        this.exercise.exerciseTagList.push(exerciseTag);
        this.modalService.dismissAll('New Tag added');
    }

    showExistingTags(modalContent) {
        console.log('open Modal for existing tags');

        // open Modal for existingTags
        this.modalService.open(modalContent, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
            console.log('Closed with ' + result);
        }, (reason) => {
            console.log('Dismissed ' + this.getDismissReason(reason));
        });

        this.existingTagForm.reset();
    }

    addExistingTag(formData) {
        let exerciseTag = new ExerciseTag();
        exerciseTag.tag = formData.tag;

        this.exercise.exerciseTagList.push(exerciseTag);
        this.modalService.dismissAll('Existing Tag added');
    }

    removeTag(id: number) {
        console.log('remove tag with id ' + id);

        this.exercise.exerciseTagList.splice(id, 1);
    }

    private getDismissReason(reason: any): string {
        if (reason === ModalDismissReasons.ESC) {
          return 'by pressing ESC';
        } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
          return 'by clicking on a backdrop';
        } else {
          return `with: ${reason}`;
        }
      }
}