import { Component, Input, OnInit, Output } from '@angular/core';
import { Exercise } from '../data-objects/create-exercise/exercise';
import { CreateExerciseService } from '../services/create-exercise.service';
import { Tag } from '../data-objects/tag';
import { WrittenLanguage } from '../data-objects/written-language';
import { ProgrammingLanguage } from '../data-objects/programming-language';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';
import { QuestionType } from '../data-objects/question-type';
import { CreateExerciseHelperService } from './create-exercise-helper.service';
import { TestCase } from '../data-objects/create-exercise/test-case';
import { Router } from '@angular/router';
import { ExerciseLanguage } from '../data-objects/create-exercise/exercise-language';
import { TestSuite } from '../data-objects/create-exercise/test-suite';
import { ExerciseBody } from '../data-objects/create-exercise/exercise-body';
import { HttpResponse } from '@angular/common/http';
import * as $ from "jquery";
import "bootstrap";

@Component({
  selector: 'app-exercise-create',
  templateUrl: './exercise-create.component.html',
  styleUrls: ['./exercise-create.component.css']
})
export class ExerciseCreateComponent implements OnInit {

  httpResponse: HttpResponse<Object>;
  errorMsg: string;
  exercise: Exercise;
  selectedElement = 'General';

  dataToCreateExercise: PrepareCreateExercise;
  writtenLangs: WrittenLanguage[];
  programmingLangs: ProgrammingLanguage[];
  questionTypes: QuestionType[];
  tagList: Tag[];

  usedWLangs: WrittenLanguage[] = [];
  usedPLangs: ProgrammingLanguage[] = [];
  langsAvailable = true;
  pLangsAvailable = true;

  writtenLangIdx: number;
  programmingLangIdx: number;
  testIdx: number;
  latestVersion: number = 0;
  testCases: number[] = [];

  constructor(private createExerciseService: CreateExerciseService, private helper: CreateExerciseHelperService, private router: Router) {}

  createExerciseObserver = {
    next: x => { if (x != undefined) { this.SaveExercise = x.body; this.httpResponse = x } else { this.httpResponse = undefined }},
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      if (this.httpResponse == undefined) {
        this.errorMsg = "Unable to create Exercise!";
        $('.toast').toast('show');
      } 
      else if (this.httpResponse.status == 200) {
        this.router.navigate(['/']);
      }
    }
  }

  createTempExerciseObserver = {
    next: x => { if (x != undefined) { this.exercise = x.body; this.httpResponse = x } else { this.httpResponse = undefined }},
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      if (this.httpResponse == undefined) {
        this.errorMsg = "Unable to temporarily save Exercise!";
        $('.toast').toast('show');
      }
    }
  }

  prepareExerciseObserver = {
    next: x => { if (x != undefined) { this.dataToCreateExercise = x.body; this.httpResponse = x } else { this.httpResponse = undefined }},
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      if (this.httpResponse == undefined) {
        this.errorMsg = "Unable to prepare Exercise!";
        $('.toast').toast('show');
      }
      else if (this.httpResponse.status == 200) {
        this.writtenLangs = this.dataToCreateExercise.writtenLanguageList;
        this.programmingLangs = this.dataToCreateExercise.programmingLanguageList;
        this.questionTypes = this.dataToCreateExercise.questionTypeList;
        this.tagList = this.dataToCreateExercise.tagList;
  
        for (let idx = 0; idx < this.writtenLangs.length; idx++) {
          // remove default written lang:
          if (this.writtenLangs[idx].name == "English") {
            this.exercise.exerciseVersionList[0].exerciseLanguageList[0].writtenLanguage = this.writtenLangs[idx];
            this.usedWLangs.push(this.writtenLangs[idx]);
            this.writtenLangs.splice(idx, 1);
          }
        }
  
        if (this.exercise.title !== undefined && this.exercise.title !== "") {
          // remove already used written and programming langs
          this.latestVersion = this.exercise.exerciseVersionList.length - 1;
          this.exercise.exerciseVersionList[this.latestVersion].exerciseLanguageList.forEach(exerciseLang => {
            let writtenLang = exerciseLang.writtenLanguage;
            if (this.writtenLangs.find(e => e.name === writtenLang.name) !== undefined) {
              let element = this.writtenLangs.find(e => e.name === writtenLang.name);
              this.usedWLangs.push(element);
              let idx = this.writtenLangs.indexOf(element);
              this.writtenLangs.splice(idx, 1);
            }
          });
          this.exercise.exerciseVersionList[this.latestVersion].exerciseLanguageList[0].exerciseBody.forEach(body => {
            let programmingLang = body.programmingLanguage;
            if (this.programmingLangs.find(e => e.name === programmingLang.name) !== undefined) {
              let element = this.programmingLangs.find(e => e.name === programmingLang.name);
              this.usedPLangs.push(element);
              let idx = this.programmingLangs.indexOf(element);
              this.programmingLangs.splice(idx, 1);
            }
  
            let testAmount = body.testSuite.testCaseList.length;
  
            this.testCases.push(testAmount);
          });
          if (this.writtenLangs.length == 0) {
            this.langsAvailable = false;
          }
          if (this.programmingLangs.length == 0) {
            this.pLangsAvailable = false;
          }
        }
      }
    }
  }

  ngOnInit() {
    this.createExerciseService.prepareExercise().subscribe(this.prepareExerciseObserver);
    this.exercise = this.createExerciseService.editExercise;

    console.log(this.exercise);

    if (this.exercise === undefined) {
      this.exercise = this.helper.createNewExercise();
    }
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
    console.log(this.exercise);
  }

  addNewTest(test: TestCase) {
    this.exercise.exerciseVersionList[this.latestVersion].exerciseLanguageList[0].exerciseBody[this.programmingLangIdx].testSuite.testCaseList.push(test);
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

  SaveExercise() {
    this.exercise = this.helper.copyBodyData(this.exercise);
    console.log(this.exercise);

    this.createExerciseService.saveExercise(this.exercise).subscribe(this.createExerciseObserver);
    this.createExerciseService.editExercise = undefined;
  }

  SaveTempExercise() {
    this.exercise = this.helper.copyBodyData(this.exercise);
    console.log(this.exercise);

    this.createExerciseService.saveTempExercise(this.exercise).subscribe(this.createTempExerciseObserver);
    this.createExerciseService.editExercise = undefined;
  }

  removeWLang(lang: WrittenLanguage) {
    this.exercise = this.helper.removeWLang(lang, this.exercise);
  }

  removePLang(lang: ProgrammingLanguage) {
    this.exercise = this.helper.removePLang(lang, this.exercise);
  }

  exerciseChanged(ex: Exercise) {
    this.exercise = ex;
  }

  wLangChanged(exerciseLang: ExerciseLanguage) {
    this.exercise.exerciseVersionList[this.latestVersion].exerciseLanguageList[this.writtenLangIdx] = exerciseLang;
  }

  bodyChanged(body: ExerciseBody) {
    this.exercise.exerciseVersionList[this.latestVersion].exerciseLanguageList[0].exerciseBody[this.programmingLangIdx] = body;
  }

  wLangBodyChanged(body: ExerciseBody) {
    this.exercise.exerciseVersionList[this.latestVersion].exerciseLanguageList[0].exerciseBody[this.programmingLangIdx] = body;
  }

  testSuiteChanged(suite: TestSuite) {
    this.exercise.exerciseVersionList[this.latestVersion].exerciseLanguageList[0].exerciseBody[this.programmingLangIdx].testSuite = suite;
  }

  testCaseChanged(test: TestCase) {
    this.exercise.exerciseVersionList[this.latestVersion].exerciseLanguageList[0].exerciseBody[this.programmingLangIdx].testSuite.testCaseList[this.testIdx] = test;
  }
}
