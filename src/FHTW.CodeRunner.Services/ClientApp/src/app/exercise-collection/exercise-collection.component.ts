import { Component, OnInit } from '@angular/core';
import { ExerciseHome } from '../data-objects/exercise-home';
import { CollectionLanguage } from '../data-objects/exercise-collection/collection-language';
import { Collection } from '../data-objects/exercise-collection/collection';
import { CollectionTag } from '../data-objects/exercise-collection/collection-tag';
import { WrittenLanguage } from '../data-objects/written-language';
import { Tag } from '../data-objects/tag';
import { FormBuilder } from '@angular/forms';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CollectionDataService } from '../services/exercise-collection.data.service';
import { CollectionExercise } from '../data-objects/exercise-collection/collection-exercise';
import { Author } from '../data-objects/author';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';
import { CreateExerciseService } from '../services/create-exercise.service';
import { ProgrammingLanguage } from '../data-objects/programming-language';
import { Router } from '@angular/router';
import { HttpResponse } from '@angular/common/http';
import * as $ from "jquery";
import "bootstrap";

@Component({
  selector: 'app-exercise-collection',
  templateUrl: './exercise-collection.component.html',
  styleUrls: ['./exercise-collection.component.css']
})
export class ExerciseCollectionComponent implements OnInit{
  
  httpResponse: HttpResponse<Object>;
  errorMsg: string;
  collection: Collection = new Collection();
  exerciseList: ExerciseHome[];
  availableLangs: WrittenLanguage[] = [{id: 1, name: "English"}];
  globalLangs: WrittenLanguage[];
  globalProgLangs: ProgrammingLanguage[];
  collectionLangsList: CollectionLanguage[] = [{id: 0, fullTitle: "", shortTitle: "", introduction: "", writtenLanguage: {id: 1, name: "English"}}];
  collectionExerciseList: CollectionExercise[] = [];
  showHeadDiv = true;
  isLangAvailable = true;

  selectedGlobalLang: number;
  selectedGlobalProgLang: number;
  
  dataLists: PrepareCreateExercise;

  existingTags: Tag[];
  newTagForm;
  existingTagForm;

  constructor(
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private collectionDataService: CollectionDataService,
    private createExerciseService: CreateExerciseService,
    private router: Router
    ) {
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

  SaveCollection() {
    this.collection.user = new Author();
    this.collection.user.id = (localStorage.getItem('user_id') !== null) ? parseInt(localStorage.getItem('user_id')) : 0;
    this.collection.user.name = localStorage.getItem('name');
    this.collection.collectionExerciseList = this.collectionExerciseList;
    this.collection.collectionLanguageList = this.collectionLangsList;

    this.collectionDataService.saveCollection(this.collection).subscribe(this.createCollectionObserver);
  }

  prepareExerciseObserver = {
    next: x => { if (x != undefined) { this.dataLists = x.body; this.httpResponse = x } else { this.httpResponse = undefined }},
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      if (this.httpResponse == undefined) {
        this.errorMsg = "Unable to get Data!";
        $('.toast').toast('show');
      }
      else if (this.httpResponse.status == 200) {
        this.availableLangs = this.dataLists.writtenLanguageList;
        this.globalLangs = [...this.dataLists.writtenLanguageList];
        this.globalProgLangs = this.dataLists.programmingLanguageList;
        this.existingTags = this.dataLists.tagList;
  
        for (let idx = 0; idx < this.availableLangs.length; idx++) {
          // remove default written lang:
          if (this.availableLangs[idx].name == "English") {
            this.availableLangs.splice(idx, 1);
          }
        }
      }
    }
  }

  createCollectionObserver = {
    next: x => { if (x != undefined) { this.SaveCollection = x.body; this.httpResponse = x } else { this.httpResponse = undefined}},
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      if (this.httpResponse == undefined) {
        this.errorMsg = "Unable to create Collection!";
        $('.toast').toast('show');
      }
      else if (this.httpResponse.status == 200) {
        console.log("Collection was saved to database")
        this.collectionDataService.sharedExerciseList = [];
        this.collectionDataService.exerciseCounter = 0;
        this.collection = null;
        this.router.navigate(['/']);
      }
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

  RemoveExercise(ex: ExerciseHome) {
    let id = this.exerciseList.indexOf(ex);
    this.exerciseList.splice(id, 1);
    this.collectionDataService.decreaseExerciseCounter();
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

  getClass(idx: number) {
    if (this.selectedGlobalLang !== undefined && this.collectionExerciseList[idx].writtenLanguageId !== this.selectedGlobalLang) {
      return 'redBorder';
    }

    return '';
  }

  getClassProg(idx: number) {
    if (this.selectedGlobalProgLang !== undefined && this.collectionExerciseList[idx].programmingLanguageId !== this.selectedGlobalProgLang) {
      return 'redBorder';
    }

    return '';
  }

  languageChangeEvent() {
    for (let i = 0; i < this.exerciseList.length; i++) {
      let found = false;
      this.exerciseList[i].writtenLanguageList.forEach(lang => {
        if (lang.id === this.selectedGlobalLang) {
          found = true;
        }
      });

      if (found) {
        this.collectionExerciseList[i].writtenLanguageId = this.selectedGlobalLang;
      }
    }
  }

  pLanguageChangeEvent() {
    for (let i = 0; i < this.exerciseList.length; i++) {
      let found = false;
      this.exerciseList[i].programmingLanguageList.forEach(lang => {
        if (lang.id === this.selectedGlobalProgLang) {
          found = true;
        }
      });

      if (found) {
        this.collectionExerciseList[i].programmingLanguageId = this.selectedGlobalProgLang;
      }
    }
  }
}
