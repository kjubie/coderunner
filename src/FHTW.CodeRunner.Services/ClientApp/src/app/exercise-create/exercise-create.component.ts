import { Component, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Exercise } from '../data-objects/exercise';
import { ExerciseLanguage } from '../data-objects/exercise-language';
import { ExerciseVersion } from '../data-objects/exercise-version';
import { CreateExerciseService } from '../data-objects/exercise.service';
import { Tag } from '../data-objects/tag';
import { TestCase } from '../data-objects/test-case';

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
    // this.exercise.exerciseVersionList[0].exerciseLanguageList[0].exerciseBody.testSuit.testCaseList[0] = new TestCase();
  }
}
