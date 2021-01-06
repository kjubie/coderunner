import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { ModalDismissReasons, NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Exercise } from "src/app/data-objects/create-exercise/exercise";
import { Tag } from "src/app/data-objects/tag";

@Component({
    selector: 'general-tab',
    templateUrl: './general-tab.component.html',
    styleUrls: ['../../exercise-create.component.css']
})
export class GeneralTabComponent implements OnInit {

    @Input() exercise: Exercise;
    @Input() existingTags: Tag[];

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

    ngOnInit() {
        this.existingTags = [];

        for (let i=0; i<5; i++) {
            let tag = new Tag();
            tag.id = i+1;
            tag.name = 'Test ' + tag.id.toString();

            this.existingTags.push(tag);
        }
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

        this.exercise.exerciseTag.push(tag);
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
        this.exercise.exerciseTag.push(formData.tag);
        this.modalService.dismissAll('Existing Tag added');
    }

    removeTag(id: number) {
        console.log('remove tag with id ' + id);

        this.exercise.exerciseTag.splice(id, 1);
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