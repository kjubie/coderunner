import { Component, OnInit, Output } from '@angular/core';
import { Exercise } from '../data-objects/create-exercise/exercise';
import { ExerciseLanguage } from '../data-objects/create-exercise/exercise-language';
import { ExerciseVersion } from '../data-objects/create-exercise/exercise-version';
import { CreateExerciseService } from '../services/create-exercise.service';
import { Tag } from '../data-objects/tag';
import { WrittenLanguage } from '../data-objects/written-language';
import { ExerciseBody } from '../data-objects/create-exercise/exercise-body';
import { TestSuit } from '../data-objects/create-exercise/test-suit';
import { TestCase } from '../data-objects/create-exercise/test-case';
import { ProgrammingLanguage } from '../data-objects/programming-language';

@Component({
  selector: 'app-exercise-create',
  templateUrl: './exercise-create.component.html',
  styleUrls: ['./exercise-create.component.css']
})
export class ExerciseCreateComponent implements OnInit {

  tabSelected: string = "general";
  writtenLang: string[] = ["English", "German"];
  programmingLang: string[] = ["C#", "Java", "Python", "C++"];
  @Output() exercise: Exercise;
  savedExercise: Exercise;
  selectedElement = 'General';

  constructor(private createExerciseService: CreateExerciseService) {}
  
  setTab(tab: string) {
    this.tabSelected = tab;
  }

  saveExercise(ex: Exercise) {
    console.log(ex);
    this.createExerciseService.saveExercise(ex).subscribe(this.createExerciseObserver);
  }

  createExerciseObserver = {
    next: x => { this.saveExercise = x },
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      console.log("exercise was saved to database")
    }
  }

  ngOnInit() {
    this.exercise = new Exercise();
    this.exercise.created = new Date();
    this.exercise.exerciseTagList[0] = new Tag();
    this.exercise.exerciseVersionList[0] = new ExerciseVersion();
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0] = new ExerciseLanguage();
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].writtenLanguage = new WrittenLanguage();
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].writtenLanguage.name = 'German';
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].exerciseBody = new ExerciseBody();
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].exerciseBody.testSuit = new TestSuit();
    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].exerciseBody.testSuit.testCaseList[0] = new TestCase();
  }

  setSelectedElement(element: string) {
    this.selectedElement = element;
  }

  addWrittenLang(lang: string) {
    let exerciseLang = new ExerciseLanguage();
    exerciseLang.writtenLanguage = new WrittenLanguage();
    exerciseLang.writtenLanguage.name = lang;
    this.exercise.exerciseVersionList[0].exerciseLanguageList.push(exerciseLang);
    console.log(this.exercise.exerciseVersionList[0].exerciseLanguageList);
  }

  addProgrammingLang(lang: string) {
    let exerciseBody = new ExerciseBody();
    exerciseBody.programmingLanguage = new ProgrammingLanguage();
    exerciseBody.programmingLanguage.name = lang;

    this.exercise.exerciseVersionList[0].exerciseLanguageList[0].exerciseBody = exerciseBody;
  }
}
