import { Component, OnInit, Output } from '@angular/core';
import { Exercise } from '../data-objects/create-exercise/exercise';
import { CreateExerciseService } from '../services/create-exercise.service';
import { Tag } from '../data-objects/tag';
import { WrittenLanguage } from '../data-objects/written-language';
import { ProgrammingLanguage } from '../data-objects/programming-language';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';
import { QuestionType } from '../data-objects/question-type';
import { CreateExerciseHelperService } from './create-exercise-helper.service';
import { TestCase } from '../data-objects/create-exercise/test-case';

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
          this.exercise.exerciseVersionList[0].exerciseLanguageList[0].writtenLanguage = this.writtenLangs[idx];
          this.writtenLangs.splice(idx, 1);
        }
      }
    }
  }

  ngOnInit() {
    this.createExerciseService.prepareExercise().subscribe(this.prepareExerciseObserver);

    this.exercise = this.helper.createNewExercise();
    this.writtenLangIdx = 0;
    this.programmingLangIdx = 0;
    this.testIdx = 0;
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
      split = this.selectedElement.split('Programming');
      split = split[1].split('_');
      
      this.programmingLangIdx = parseInt(split[0]);

      if (this.selectedElement.includes('TestCase')) {
        split = this.selectedElement.split('TestCase');
        this.testIdx = parseInt(split[1]);

        console.log(this.testIdx);
      }
      else if (this.selectedElement.includes('Lang')) {
        split = this.selectedElement.split('Lang');

        this.writtenLangIdx = parseInt(split[1]);
      }
    }
  }

  addWrittenLang(lang: WrittenLanguage) {
    this.exercise = this.helper.addWrittenLang(lang, this.exercise);
  }

  addProgrammingLang(lang: ProgrammingLanguage) {
    this.exercise = this.helper.addProgrammingLang(lang, this.exercise);
  }

  addNewTest(test: TestCase) {
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].exerciseBody[this.programmingLangIdx].testSuite.testCaseList.push(test);

    console.log(this.exercise.exerciseVersionList[0].exerciseLanguageList[0].exerciseBody[this.programmingLangIdx].testSuite.testCaseList);
  }

  removeTestCase(idx: number) {
    if (this.selectedElement.includes('TestCase') && this.testIdx == idx) {
      console.log('set to prev. testcase...')
      this.testIdx -= 1;
      let split = this.selectedElement.split("_");
      let newIdx = 'TestCase' + this.testIdx.toString();
      this.selectedElement = split[0] + '_' + newIdx;
    }

    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].exerciseBody[this.programmingLangIdx].testSuite.testCaseList.pop();
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
