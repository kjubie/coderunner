import { Injectable } from "@angular/core";
import { Author } from "../data-objects/author";
import { Exercise } from "../data-objects/create-exercise/exercise";
import { ExerciseBody } from "../data-objects/create-exercise/exercise-body";
import { ExerciseLanguage } from "../data-objects/create-exercise/exercise-language";
import { ExerciseVersion } from "../data-objects/create-exercise/exercise-version";
import { TestCase } from "../data-objects/create-exercise/test-case";
import { TestSuite } from "../data-objects/create-exercise/test-suite";
import { ProgrammingLanguage } from "../data-objects/programming-language";
import { WrittenLanguage } from "../data-objects/written-language";
import { cloneDeep } from "lodash";

@Injectable({
    providedIn: 'root'
})
export class CreateExerciseHelperService {

  createNewExercise(): Exercise {
    let exercise = new Exercise();

    exercise.fkUser = new Author();
    exercise.fkUser.id = (localStorage.getItem('user_id') !== null) ? parseInt(localStorage.getItem('user_id')) : 0;
    exercise.fkUser.name = localStorage.getItem('name');

    exercise.exerciseVersion[0] = new ExerciseVersion();
    exercise.exerciseVersion[0].fkUser = exercise.fkUser;
    exercise.exerciseVersion[0].validState = 0;
    exercise.exerciseVersion[0].creatorDifficulty = 0;
    exercise.exerciseVersion[0].creatorRating = 0;
    exercise.exerciseVersion[0].versionNumber = 0;

    exercise.exerciseVersion[0].exerciseLanguage[0] = new ExerciseLanguage();
    exercise.exerciseVersion[0].exerciseLanguage[0].fkWrittenLanguage = new WrittenLanguage();
    exercise.exerciseVersion[0].exerciseLanguage[0].exerciseBody[0] = new ExerciseBody();
          
    return exercise;
  }

  getCorrectIdx(selectedLang: string, exercise: Exercise): number {
    let idx = 0;
    
    for (let i=0; i<exercise.exerciseVersion[0].exerciseLanguage.length; i++) {
      if (exercise.exerciseVersion[0].exerciseLanguage[i].exerciseBody[0].fkProgrammingLanguage.name === selectedLang) {
        idx = i;
        break;
      }
    }
    
    return idx;
  }

  addWrittenLang(lang: WrittenLanguage, exercise: Exercise): Exercise {
    let toBeAdded: ExerciseLanguage[] = [];
    exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
      // check if exercise already has body with pLang
      if (el.exerciseBody[0] != undefined && el.exerciseBody[0].fkProgrammingLanguage != undefined) {
        // let newLang = Object.assign(new ExerciseLanguage(), el); // ToDo: make deepcopy
        let newLang = cloneDeep(el);
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
      if (toAdd.exerciseBody[0].fkProgrammingLanguage == undefined) {
        exercise.exerciseVersion[0].exerciseLanguage.push(toAdd);
      }
      else {
        let exerciseLangs: ExerciseLanguage[] = [];
        exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
          exerciseLangs.push(el);
          if (toAdd.exerciseBody[0].fkProgrammingLanguage.name === el.exerciseBody[0].fkProgrammingLanguage.name) {
            exerciseLangs.push(toAdd);
          }
        });
    
        exercise.exerciseVersion[0].exerciseLanguage = exerciseLangs;
      }
    });

    return exercise;
  }

  addProgrammingLang(lang: ProgrammingLanguage, exercise: Exercise): Exercise {
    let toBeAdded: ExerciseLanguage[] = [];
    let englishAdded = false;
    let germanAdded = false;
        
    // add programming lang for all written langs
    exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
      // check if a programming lang already exists
      if (el.exerciseBody[0].fkProgrammingLanguage.name == undefined) {
        el.exerciseBody[0] = new ExerciseBody();
        el.exerciseBody[0].fkTestSuite = new TestSuite();
        el.exerciseBody[0].fkTestSuite.testCase = [new TestCase()];
        el.exerciseBody[0].fkProgrammingLanguage = lang
      }
      else {
        if (el.fkWrittenLanguage.name == 'English' && !englishAdded) {
          toBeAdded = this.createNewExerciseLang(toBeAdded, el, lang);
          englishAdded = true;
        }
        else if (el.fkWrittenLanguage.name == 'German' && !germanAdded) {
          toBeAdded = this.createNewExerciseLang(toBeAdded, el, lang);
          germanAdded = true;
        }
      }
    });

    toBeAdded.forEach(el => {
      exercise.exerciseVersion[0].exerciseLanguage.push(el);
    });

    return exercise;
  }

  removeWLang(lang: WrittenLanguage, exercise: Exercise): Exercise {
    let toBeRemoved = [];
    
    exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
      if (el.fkWrittenLanguage.name === lang.name) {
        let idx = exercise.exerciseVersion[0].exerciseLanguage.indexOf(el);
        toBeRemoved.push(idx);
      }
    });
    
    for (let i = toBeRemoved.length-1; i >= 0; i--) {
      exercise.exerciseVersion[0].exerciseLanguage.splice(toBeRemoved[i], 1);
    }

    return exercise;
  }
    
  removePLang(lang: ProgrammingLanguage, exercise: Exercise): Exercise {
    let toBeRemoved = [];
    
    exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
      if (el.exerciseBody[0].fkProgrammingLanguage.name === lang.name) {
        let idx = exercise.exerciseVersion[0].exerciseLanguage.indexOf(el);
        toBeRemoved.push(idx);
      }
    });
    
    for (let i = toBeRemoved.length-1; i >= 0; i--) {
      exercise.exerciseVersion[0].exerciseLanguage.splice(toBeRemoved[i], 1);
    }

    return exercise;
  } 

  copyBodyData(exercise: Exercise): Exercise {
    let bodyToCopy: ExerciseBody = null;

    exercise.exerciseVersion[0].exerciseLanguage.forEach(el => {
      if (bodyToCopy === null || !(el.exerciseBody[0].fkProgrammingLanguage === bodyToCopy.fkProgrammingLanguage)) {
        bodyToCopy = el.exerciseBody[0];
      }
      else {
        el.exerciseBody[0].fkTestSuite = bodyToCopy.fkTestSuite;
        el.exerciseBody[0].fkProgrammingLanguage = bodyToCopy.fkProgrammingLanguage;
        el.exerciseBody[0].description = bodyToCopy.description;
        el.exerciseBody[0].hint = bodyToCopy.hint;
        el.exerciseBody[0].fieldLines = bodyToCopy.fieldLines;
        el.exerciseBody[0].subtractSystem = bodyToCopy.subtractSystem;
        el.exerciseBody[0].obtainablePoints = bodyToCopy.obtainablePoints;
        el.exerciseBody[0].idNum = bodyToCopy.idNum;
        el.exerciseBody[0].solution = bodyToCopy.solution;
        el.exerciseBody[0].prefill = bodyToCopy.prefill;
        el.exerciseBody[0].allowFiles = bodyToCopy.allowFiles;
        el.exerciseBody[0].filesRequired = bodyToCopy.filesRequired;
        el.exerciseBody[0].filesRegex = bodyToCopy.filesRegex;
        el.exerciseBody[0].filesDescription = bodyToCopy.filesDescription;
        el.exerciseBody[0].filesSize = bodyToCopy.filesSize;
        el.exerciseBody[0].example = bodyToCopy.example;
      }
    });

    return exercise;
  }

  private createNewExerciseLang(toBeAdded: ExerciseLanguage[], source: ExerciseLanguage, lang: ProgrammingLanguage) {
    let exerciseLang = cloneDeep(source);
    exerciseLang.exerciseBody[0] = new ExerciseBody();
    
    exerciseLang.exerciseBody[0].fkTestSuit = new TestSuite();
    exerciseLang.exerciseBody[0].fkTestSuit.testCase = [new TestCase()];
    exerciseLang.exerciseBody[0].fkProgrammingLanguage = lang
    
    toBeAdded.push(exerciseLang);
    
    return toBeAdded;
  }
}