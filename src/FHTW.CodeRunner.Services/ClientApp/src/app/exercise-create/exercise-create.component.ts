import { Component, OnInit, Output } from '@angular/core';
import { Exercise } from '../data-objects/create-exercise/exercise';
import { ExerciseLanguage } from '../data-objects/create-exercise/exercise-language';
import { ExerciseVersion } from '../data-objects/create-exercise/exercise-version';
import { CreateExerciseService } from '../services/create-exercise.service';
import { Tag } from '../data-objects/tag';
import { WrittenLanguage } from '../data-objects/written-language';
import { ExerciseBody } from '../data-objects/create-exercise/exercise-body';
import { ProgrammingLanguage } from '../data-objects/programming-language';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';
import { QuestionType } from '../data-objects/question-type';
import { TestSuit } from '../data-objects/create-exercise/test-suit';
import { TestCase } from '../data-objects/create-exercise/test-case';

@Component({
  selector: 'app-exercise-create',
  templateUrl: './exercise-create.component.html',
  styleUrls: ['./exercise-create.component.css']
})
export class ExerciseCreateComponent implements OnInit {

  selectedElement = 'General';

  dataToCreateExercise: PrepareCreateExercise;
  writtenLangs: WrittenLanguage[];
  programmingLangs: ProgrammingLanguage[];
  questionTypes: QuestionType[];
  writtenLangIdx: number;
  programmingLangIdx: number;
  testIdx: number;
  programmingWrittenLangIdx: number;

  savedExercise: Exercise;
  @Output() exercise: Exercise;
  

  constructor(private createExerciseService: CreateExerciseService) {}

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

      for (let i=0; i<this.writtenLangs.length; i++) {
        // remove default written lang:
        if (this.writtenLangs[i].name == "English") {
          this.writtenLangs.splice(i, 1);
        }
      }
    }
  }

  ngOnInit() {
    this.createExerciseService.prepareExercise().subscribe(this.prepareExerciseObserver);

    this.exercise = new Exercise();
    this.exercise.created = new Date();
    this.exercise.exerciseTagList[0] = new Tag();
    this.exercise.exerciseVersionList[0] = new ExerciseVersion();
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0] = new ExerciseLanguage();
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].writtenLanguage = new WrittenLanguage();
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].writtenLanguage.name = 'English';
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
        this.programmingWrittenLangIdx = parseInt(split[1]);
      }
    }
  }

  addWrittenLang(lang: WrittenLanguage) {
    let exerciseLang = new ExerciseLanguage();
    exerciseLang.writtenLanguage = lang;
    this.exercise.exerciseVersionList[0].exerciseLanguageList.push(exerciseLang);

    // console.log(this.exercise);
  }

  addProgrammingLang(lang: ProgrammingLanguage) {
    let toBeAdded: ExerciseLanguage[] = [];
    let exerciseBody = new ExerciseBody();
    exerciseBody.testSuit = new TestSuit();
    exerciseBody.testSuit.testCaseList = [new TestCase()];
    exerciseBody.programmingLanguage = lang
    
    // add programming lang for all written langs
    for (let i=0; i<this.exercise.exerciseVersionList[0].exerciseLanguageList.length; i++) {
      // check if a programming lang already exists
      if (this.exercise.exerciseVersionList[0].exerciseLanguageList[i].exerciseBody.programmingLanguage == undefined) {
        this.exercise.exerciseVersionList[0].exerciseLanguageList[i].exerciseBody = exerciseBody;
      }
      else {
        // ToDo
        // let exerciseLang = this.exercise.exerciseVersionList[0].exerciseLanguageList[i];
        // exerciseLang.exerciseBody = exerciseBody;

        // toBeAdded.push(exerciseLang);
      }
    }

    // add new Programming Langs if needed
    if (toBeAdded.length > 0) {
      // ToDo
    }

    console.log(this.exercise);
  }

  saveExercise() {
    console.log(this.exercise);
    this.createExerciseService.saveExercise(this.exercise).subscribe(this.createExerciseObserver);
  }
}
