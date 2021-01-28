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

    exercise.user = new Author();
    exercise.user.id = (localStorage.getItem('user_id') !== null) ? parseInt(localStorage.getItem('user_id')) : 0;
    exercise.user.name = localStorage.getItem('name');

    exercise.exerciseVersionList[0] = new ExerciseVersion();
    exercise.exerciseVersionList[0].user = exercise.user;
    exercise.exerciseVersionList[0].validState = 0;
    exercise.exerciseVersionList[0].creatorDifficulty = 0;
    exercise.exerciseVersionList[0].creatorRating = 0;
    exercise.exerciseVersionList[0].versionNumber = 0;

    exercise.exerciseVersionList[0].exerciseLanguageList[0] = new ExerciseLanguage();
    exercise.exerciseVersionList[0].exerciseLanguageList[0].writtenLanguage = new WrittenLanguage();
    exercise.exerciseVersionList[0].exerciseLanguageList[0].exerciseBody[0] = new ExerciseBody();
          
    return exercise;
  }

  addWrittenLang(lang: WrittenLanguage, exercise: Exercise): Exercise {
    let toBeAdded: ExerciseLanguage[] = [];

    exercise.exerciseVersionList[0].exerciseLanguageList.forEach(el => {
      // check if exercise already has body with pLang
      if (el.exerciseBody[0] != undefined && el.exerciseBody[0].programmingLanguage != undefined) {
        let newLang = cloneDeep(el);
        newLang = this.resetIds(newLang);
        newLang.writtenLanguage = lang;

        toBeAdded.push(newLang);
      }
      else {
        let exerciseLang = new ExerciseLanguage();
        exerciseLang.writtenLanguage = lang;
    
        toBeAdded.push(exerciseLang);
      }
    });
    
    toBeAdded.forEach(toAdd => {
      exercise.exerciseVersionList[0].exerciseLanguageList.push(toAdd);
    });
    
    return exercise;
  }

  addProgrammingLang(lang: ProgrammingLanguage, exercise: Exercise): Exercise {        
    // add programming lang for all written langs
    exercise.exerciseVersionList[0].exerciseLanguageList.forEach(el => {
      // check if a programming lang already exists
      if (el.exerciseBody[0].programmingLanguage.name == undefined) {
        el.exerciseBody[0] = this.createNewBody(lang);
      }
      else {
        el.exerciseBody.push(this.createNewBody(lang));
      }
    });

    return exercise;
  }

  removeWLang(lang: WrittenLanguage, exercise: Exercise): Exercise {
    let toBeRemoved = [];
    
    exercise.exerciseVersionList[0].exerciseLanguageList.forEach(el => {
      if (el.writtenLanguage.name === lang.name) {
        let idx = exercise.exerciseVersionList[0].exerciseLanguageList.indexOf(el);
        toBeRemoved.push(idx);
      }
    });
    
    for (let i = toBeRemoved.length-1; i >= 0; i--) {
      exercise.exerciseVersionList[0].exerciseLanguageList.splice(toBeRemoved[i], 1);
    }

    return exercise;
  }
    
  removePLang(lang: ProgrammingLanguage, exercise: Exercise): Exercise {
    let toBeRemoved = [];

    exercise.exerciseVersionList[0].exerciseLanguageList.forEach(el => {
      // check each body
      el.exerciseBody.forEach(body => {
        if (body.programmingLanguage.name === lang.name) {
          let elIdx = exercise.exerciseVersionList[0].exerciseLanguageList.indexOf(el);
          let bodyIdx = el.exerciseBody.indexOf(body);

          let remove = {
            el: elIdx,
            body: bodyIdx
          }

          toBeRemoved.push(remove);
        }
      })
    });
    
    for (let i = toBeRemoved.length-1; i >= 0; i--) {
      let remove = toBeRemoved[i];
      exercise.exerciseVersionList[0].exerciseLanguageList[remove.el].exerciseBody.splice(remove.body, 1);
    }

    return exercise;
  } 

  copyBodyData(exercise: Exercise): Exercise {
    let bodyToCopy: ExerciseBody = null;

    exercise.exerciseVersionList[0].exerciseLanguageList.forEach(el => {
      if (bodyToCopy === null || !(el.exerciseBody[0].programmingLanguage === bodyToCopy.programmingLanguage)) {
        bodyToCopy = el.exerciseBody[0];
      }
      else {
        el.exerciseBody[0].testSuite = bodyToCopy.testSuite;
        el.exerciseBody[0].programmingLanguage = bodyToCopy.programmingLanguage;
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

  private createNewBody(lang: ProgrammingLanguage) {
    let body = new ExerciseBody();
    body.testSuite = new TestSuite();
    body.testSuite.testCaseList = [new TestCase()];
    body.programmingLanguage = lang

    return body;
  }

  private resetIds(exerciseLang: ExerciseLanguage) {
    exerciseLang.id = 0;
    exerciseLang.exerciseHeader.id = 0;
    exerciseLang.exerciseBody.forEach(body => {
      body.id = 0;
      body.testSuite.id = 0;
      body.testSuite.testCaseList.forEach(testCase => {
        testCase.id = 0;
      });
    });

    return exerciseLang;
  }
}