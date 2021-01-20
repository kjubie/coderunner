import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ExerciseHome } from '../data-objects/exercise-home';
import { CollectionLanguage } from '../data-objects/exercise-collection/collection-language';
import { Collection } from '../data-objects/exercise-collection/collection';
import { CollectionTag } from '../data-objects/exercise-collection/collection-tag';
import { WrittenLanguage } from "../data-objects/written-language";
import { Tag } from "../data-objects/tag"
import { FormBuilder } from "@angular/forms";
import { ModalDismissReasons, NgbModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-exercise-collection',
  templateUrl: './exercise-collection.component.html',
  styleUrls: ['./exercise-collection.component.css']
})
export class ExerciseCollectionComponent {

  @Input() collectionExerciseList: ExerciseHome[];
  @Output() removeWrittenLangEvent = new EventEmitter<WrittenLanguage>();
  @Output() addWrittenLangEvent = new EventEmitter<WrittenLanguage>();
  @Output() removeExerciseEvent = new EventEmitter<ExerciseHome>();

  collection: Collection = new Collection();
  showHeadDiv = true;
  availableLangs: WrittenLanguage[] = [{id: 1, name: "English"}];
  collectionLangsList: CollectionLanguage[] = [{id: 0, fullTitle: "", shortTitle: "", introduction: "", writtenLanguage: {id: 0, name: "English"}}];
  exerciseList: ExerciseHome[] = [
    {
      id: 1,
      title: "Test",
      created: "ok",
      user: null,
      versionList: [1],
      tagList: [{id:1, name: "tag"}],
      writtenLanguageList: [{id: 1, name: "English"}],
      programmingLanguageList: [{id: 1, name: "C++"}],
    }
  ]
  isLangAvailable = true;

  collapseList(listName: string) {
    if (listName === 'headDiv') {
      this.showHeadDiv = !this.showHeadDiv;
      if (this.showHeadDiv) {
          document.getElementById('arrowHeadList').classList.remove("right");
          document.getElementById('arrowHeadList').classList.add("down");
      }
      else {
          document.getElementById('arrowHeadList').classList.remove("down");
          document.getElementById('arrowHeadList').classList.add("right");
      }
    }
  }

  addLanguage(lang: WrittenLanguage) {
    if (this.availableLangs.indexOf(lang) != -1) {
        let idx = this.availableLangs.indexOf(lang);
        this.availableLangs.splice(idx, 1);
        if (this.availableLangs.length == 0) {
            this.isLangAvailable = false;
        }
        let newColLang = new CollectionLanguage;
        newColLang.writtenLanguage = lang;
        this.collectionLangsList.push(newColLang);
        this.addWrittenLangEvent.emit(lang);
    }
  }

  removeLanguage(lang: CollectionLanguage) {
    if (this.collectionLangsList.indexOf(lang) != -1) {
        let idx = this.collectionLangsList.indexOf(lang);
        this.collectionLangsList.splice(idx, 1);
        this.availableLangs.push(lang.writtenLanguage);
        if (!this.isLangAvailable) {
            this.isLangAvailable = true;
        }
        this.removeWrittenLangEvent.emit(lang.writtenLanguage);
    }
  }

  removeExercise(ex: ExerciseHome) {
    let id = this.exerciseList.indexOf(ex);
    this.exerciseList.splice(id, 1);
    this.removeExerciseEvent.emit(ex);
  }

  // TAGS
  existingTags: Tag[];
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

      let exerciseTag = new CollectionTag();
      exerciseTag.tag = tag;

      this.collection.collectionTagList.push(exerciseTag);
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
      let exerciseTag = new CollectionTag();
      exerciseTag.tag = formData.tag;

      this.collection.collectionTagList.push(exerciseTag);
      this.modalService.dismissAll('Existing Tag added');
  }

  removeTag(id: number) {
      console.log('remove tag with id ' + id);

      this.collection.collectionTagList.splice(id, 1);
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
