import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Exercise } from '../data-objects/create-exercise/exercise';
import { CollectionLanguage } from '../data-objects/exercise-collection/collection-language';
import { Collection } from '../data-objects/exercise-collection/collection';
import { WrittenLanguage } from "../data-objects/written-language";

@Component({
  selector: 'app-exercise-collection',
  templateUrl: './exercise-collection.component.html',
  styleUrls: ['./exercise-collection.component.css']
})
export class ExerciseCollectionComponent {

  @Input() collectionExerciseList: Exercise[];
  @Output() removeWrittenLangEvent = new EventEmitter<WrittenLanguage>();
  @Output() addWrittenLangEvent = new EventEmitter<WrittenLanguage>();
  @Output() removeExerciseEvent = new EventEmitter<Exercise>();

  collection: Collection = new Collection;
  showHeadDiv = true;
  availableLangsW: WrittenLanguage[] = [{id: 1, name: "English"}];
  writtenLang: WrittenLanguage[] = [];
  exerciseList: Exercise[] = [{id: 0, title: "Test", created: null, user: null, exerciseTagList: null, exerciseVersionList: null}]
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

  removeLanguage(lang: WrittenLanguage) {
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

  removeExercise(ex: Exercise) {
    let id = this.exerciseList.indexOf(ex);
    this.exerciseList.splice(id, 1);
    this.removeExerciseEvent.emit(ex);
  }
}
