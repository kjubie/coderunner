import { Component, OnInit, Output } from '@angular/core';
import { Exercise } from '../data-objects/create-exercise/exercise';
import { CreateExerciseService } from '../services/create-exercise.service';
import { Tag } from '../data-objects/tag';
import { WrittenLanguage } from '../data-objects/written-language';
import { ProgrammingLanguage } from '../data-objects/programming-language';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';
import { QuestionType } from '../data-objects/question-type';
import { CreateExerciseHelperService } from './create-exercise-helper.service';

@Component({
  selector: 'app-exercise-create',
  templateUrl: './exercise-create.component.html',
  styleUrls: ['./exercise-create.component.css']
})
export class ExerciseCreateComponent implements OnInit {

  exercise: Exercise;
  selectedElement = 'General';

  dataToCreateExercise: PrepareCreateExercise;
  writtenLangs: WrittenLanguage[];
  programmingLangs: ProgrammingLanguage[];
  questionTypes: QuestionType[];
  tagList: Tag[];

  writtenLangIdx: number;
  programmingLangIdx: number;
  testIdx: number;

  constructor(private createExerciseService: CreateExerciseService, private helper: CreateExerciseHelperService) {}

  createExerciseObserver = {
    next: x => { this.saveExercise = x },
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      console.log("exercise was saved to database")
    }
  }

  prepareExerciseObserver = {
    next: x => { this.dataToCreateExercise = x},
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      this.writtenLangs = this.dataToCreateExercise.writtenLanguageList;
      this.programmingLangs = this.dataToCreateExercise.programmingLanguageList;
      this.questionTypes = this.dataToCreateExercise.questionTypeList;
      this.tagList = this.dataToCreateExercise.tagList;

      for (let idx = 0; idx < this.writtenLangs.length; idx++) {
        // remove default written lang:
        if (this.writtenLangs[idx].name == "English") {
          this.exercise.exerciseVersion[0].exerciseLanguage[0].fkWrittenLanguage = this.writtenLangs[idx];
          this.writtenLangs.splice(idx, 1);
        }
      }
    }
  }

  ngOnInit() {
    this.createExerciseService.prepareExercise().subscribe(this.prepareExerciseObserver);

    this.exercise = this.helper.createNewExercise(this.writtenLangs);
  }

  setSelectedElement(element: string) {
    this.selectedElement = element;
    console.log(this.selectedElement);

    let split = [];

    if (this.selectedElement.includes('WrittenLang')) {
      split = this.selectedElement.split('WrittenLang');
      this.writtenLangIdx = parseInt(split[1]);
    }
    else if (this.selectedElement.includes('Programming')) {
      split = this.selectedElement.split('Programming_');
      split = split[1].split('_');
      let selectedPLang = split[0];
      
      this.programmingLangIdx = this.helper.getCorrectIdx(selectedPLang, this.exercise);

      if (this.selectedElement.includes('TestCase')) {
        split = this.selectedElement.split('TestCase');
        this.testIdx = parseInt(split[1]);
      }
      else if (this.selectedElement.includes('Lang')) {
        split = this.selectedElement.split('Lang');

        this.programmingLangIdx += parseInt(split[1]);
      }
      console.log(this.programmingLangIdx);
    }
  }

  addWrittenLang(lang: WrittenLanguage) {
    this.exercise = this.helper.addWrittenLang(lang, this.exercise);
  }

  addProgrammingLang(lang: ProgrammingLanguage) {
    this.exercise = this.helper.addProgrammingLang(lang, this.exercise);
  }

  saveExercise() {
    // this.exercise.created = new Date().toISOString();
    // this.exercise.exerciseVersion[0].lastModified = this.exercise.created;

    this.exercise = this.helper.copyBodyData(this.exercise);
    console.log(this.exercise);

    this.createExerciseService.saveExercise(this.exercise).subscribe(this.createExerciseObserver);
  }

  removeWLang(lang: WrittenLanguage) {
    this.exercise = this.helper.removeWLang(lang, this.exercise);
  }

  removePLang(lang: ProgrammingLanguage) {
    this.exercise = this.helper.removePLang(lang, this.exercise);
  }
}
