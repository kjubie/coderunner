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
import { Author } from '../data-objects/author';

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
    
    this.exercise.created = new Date().toISOString();

    this.exercise.fkUser = new Author();
    this.exercise.fkUser.name = localStorage.getItem('name');

    this.exercise.exerciseTag[0] = new Tag();

    this.exercise.exerciseVersion[0] = new ExerciseVersion();
    this.exercise.exerciseVersion[0].fkUser = this.exercise.fkUser;
    this.exercise.exerciseVersion[0].validState = 0;
    this.exercise.exerciseVersion[0].lastModified = this.exercise.created;
    this.exercise.exerciseVersion[0].creatorDifficulty = 0;
    this.exercise.exerciseVersion[0].creatorRating = 0;
    this.exercise.exerciseVersion[0].versionNumber = 0;

    this.exercise.exerciseVersion[0].exerciseLanguage[0] = new ExerciseLanguage();
    this.exercise.exerciseVersion[0].exerciseLanguage[0].fkWrittenLanguage = new WrittenLanguage();
    this.exercise.exerciseVersion[0].exerciseLanguage[0].fkWrittenLanguage.name = 'English';
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
      
      this.programmingLangIdx = this.getCorrectIdx(selectedPLang);

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
    let toBeAdded: ExerciseLanguage[] = [];

    this.exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
      // check if exercise already has body with pLang
      if (el.exerciseBody != undefined && el.exerciseBody.fkProgrammingLanguage != undefined) {
        let newLang = Object.assign(new ExerciseLanguage(), el);
        newLang.fkWrittenLanguage = lang;

        toBeAdded.push(newLang);
      }
      else {
        let exerciseLang = new ExerciseLanguage();
        exerciseLang.fkWrittenLanguage = lang;

        toBeAdded.push(exerciseLang);
      }
    });

    // insert in specific order for easier data-binding
    toBeAdded.forEach(toAdd => {
      if (toAdd.exerciseBody.fkProgrammingLanguage == undefined) {
        this.exercise.exerciseVersion[0].exerciseLanguage.push(toAdd);
      }
      else {
        let exerciseLangs: ExerciseLanguage[] = [];
        this.exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
          exerciseLangs.push(el);
          if (toAdd.exerciseBody.fkProgrammingLanguage.name === el.exerciseBody.fkProgrammingLanguage.name) {
            exerciseLangs.push(toAdd);
          }
        });

        this.exercise.exerciseVersion[0].exerciseLanguage = exerciseLangs;
      }
    });
  }

  addProgrammingLang(lang: ProgrammingLanguage) {
    let toBeAdded: ExerciseLanguage[] = [];
    let englishAdded = false;
    let germanAdded = false;
    let exerciseBody = new ExerciseBody();
    exerciseBody.fkTestSuit = new TestSuit();
    exerciseBody.fkTestSuit.testCase = [new TestCase()];
    exerciseBody.fkProgrammingLanguage = lang
    
    // add programming lang for all written langs
    this.exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
      // check if a programming lang already exists
      if (el.exerciseBody.fkProgrammingLanguage == undefined) {
        el.exerciseBody = exerciseBody;
      }
      else {
        if (el.fkWrittenLanguage.name == 'English' && !englishAdded) {
          toBeAdded = this.createNewExerciseLang(exerciseBody, toBeAdded, el);
          englishAdded = true;
        }
        else if (el.fkWrittenLanguage.name == 'German' && !germanAdded) {
          toBeAdded = this.createNewExerciseLang(exerciseBody, toBeAdded, el);
          germanAdded = true;
        }
      }
    });

    toBeAdded.forEach(el => {
      this.exercise.exerciseVersion[0].exerciseLanguage.push(el);
    });
  }

  saveExercise() {
    console.log(this.exercise);
    this.createExerciseService.saveExercise(this.exercise).subscribe(this.createExerciseObserver);
  }

  private createNewExerciseLang(exerciseBody: ExerciseBody, toBeAdded: ExerciseLanguage[], source: ExerciseLanguage) {
    let exerciseLang = Object.assign(new ExerciseLanguage(), source);
    exerciseLang.exerciseBody = exerciseBody;

    toBeAdded.push(exerciseLang);

    return toBeAdded;
  }

  removeWLang(lang: WrittenLanguage) {
    let toBeRemoved = [];

    this.exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
      if (el.fkWrittenLanguage.name === lang.name) {
        let idx = this.exercise.exerciseVersion[0].exerciseLanguage.indexOf(el);
        toBeRemoved.push(idx);
      }
    });

    for (let i = toBeRemoved.length-1; i >= 0; i--) {
      this.exercise.exerciseVersion[0].exerciseLanguage.splice(toBeRemoved[i], 1);
    }
  }

  removePLang(lang: ProgrammingLanguage) {
    let toBeRemoved = [];

    this.exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
      if (el.exerciseBody.fkProgrammingLanguage.name === lang.name) {
        let idx = this.exercise.exerciseVersion[0].exerciseLanguage.indexOf(el);
        toBeRemoved.push(idx);
      }
    });

    for (let i = toBeRemoved.length-1; i >= 0; i--) {
      this.exercise.exerciseVersion[0].exerciseLanguage.splice(toBeRemoved[i], 1);
    }
  }

  private getCorrectIdx(selectedLang: string): number {
    let idx = 0;
    for (let i=0; i<this.exercise.exerciseVersion[0].exerciseLanguage.length; i++) {
      if (this.exercise.exerciseVersion[0].exerciseLanguage[i].exerciseBody.fkProgrammingLanguage.name === selectedLang) {
        idx = i;
        break;
      }
    }

    return idx;
  }

  copyProgrammingSpecificPartForLangs() {
    // ToDo
  }
}
