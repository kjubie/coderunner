import { Component, OnInit } from '@angular/core';
import { ExerciseHome } from '../data-objects/exercise-home';
import { CollectionLanguage } from '../data-objects/exercise-collection/collection-language';
import { Collection } from '../data-objects/exercise-collection/collection';
import { CollectionTag } from '../data-objects/exercise-collection/collection-tag';
import { WrittenLanguage } from '../data-objects/written-language';
import { Tag } from '../data-objects/tag';
import { FormBuilder } from '@angular/forms';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CollectionDataService } from './exercise-collection.data.service';
import { CollectionExercise } from '../data-objects/exercise-collection/collection-exercise';
import { Author } from '../data-objects/author';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';
import { CreateExerciseService } from '../services/create-exercise.service';
import { ProgrammingLanguage } from '../data-objects/programming-language';

@Component({
  selector: 'app-exercise-collection',
  templateUrl: './exercise-collection.component.html',
  styleUrls: ['./exercise-collection.component.css']
})
export class ExerciseCollectionComponent implements OnInit{
  
  // TODO: Global Settings
  
  collection: Collection = new Collection();
  exerciseList: ExerciseHome[];
  availableLangs: WrittenLanguage[] = [{id: 1, name: "English"}];
  globalLangs: WrittenLanguage[];
  globalProgLangs: ProgrammingLanguage[];
  collectionLangsList: CollectionLanguage[] = [{id: 0, fullTitle: "", shortTitle: "", introduction: "", writtenLanguage: {id: 1, name: "English"}}];
  collectionExerciseList: CollectionExercise[] = [];
  showHeadDiv = true;
  isLangAvailable = true;
  
  dataLists: PrepareCreateExercise;

  existingTags: Tag[];
  newTagForm;
  existingTagForm;

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder, private collectionDataService: CollectionDataService, private createExerciseService: CreateExerciseService) {
    this.newTagForm = formBuilder.group({
        tagName: ''
    });

    this.existingTagForm = formBuilder.group({
        tag: new Tag()
    });
}
  
  ngOnInit() {
    this.createExerciseService.prepareExercise().subscribe(this.prepareExerciseObserver);
    this.exerciseList = this.collectionDataService.sharedExerciseList;

    this.exerciseList.forEach(exercise => {
      this.collectionExerciseList.push(new CollectionExercise(exercise.id));
    });
  }

  saveCollection() {
    this.collection.user = new Author();
    this.collection.user.id = (localStorage.getItem('user_id') !== null) ? parseInt(localStorage.getItem('user_id')) : 0;
    this.collection.user.name = localStorage.getItem('name');
    this.collection.collectionExerciseList = this.collectionExerciseList;
    this.collection.collectionLanguageList = this.collectionLangsList;

    console.log(this.collection);

    this.collectionDataService.saveCollection(this.collection).subscribe(this.createCollectionObserver);
  }

  prepareExerciseObserver = {
    next: x => { this.dataLists = x},
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      this.availableLangs = this.dataLists.writtenLanguageList;
      this.globalLangs = [...this.dataLists.writtenLanguageList];
      this.globalProgLangs = this.dataLists.programmingLanguageList;
      this.existingTags = this.dataLists.tagList;
      console.log(this.dataLists.tagList);
      console.log(this.dataLists.writtenLanguageList);

      for (let idx = 0; idx < this.availableLangs.length; idx++) {
        // remove default written lang:
        if (this.availableLangs[idx].name == "English") {
          this.availableLangs.splice(idx, 1);
        }
      }
    }
  }

  createCollectionObserver = {
    next: x => { this.saveCollection = x },
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      console.log("Collection was saved to database")
    }
  }
  
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
        // this.addWrittenLangEvent.emit(lang);
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
        // this.removeWrittenLangEvent.emit(lang.writtenLanguage);
    }
  }

  removeExercise(ex: ExerciseHome) {
    let id = this.exerciseList.indexOf(ex);
    this.exerciseList.splice(id, 1);
    // this.removeExerciseEvent.emit(ex);
  }

  // TAGS
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

      let collectionTag = new CollectionTag();
      collectionTag.tag = tag;

      this.collection.collectionTagList.push(collectionTag);
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
      let collectionTag = new CollectionTag();
      collectionTag.tag = formData.tag;

      this.collection.collectionTagList.push(collectionTag);
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
