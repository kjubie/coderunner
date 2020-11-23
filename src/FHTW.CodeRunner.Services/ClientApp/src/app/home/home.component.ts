import { Component, OnInit } from '@angular/core';
import { Author } from '../data-objects/author';
import { ProgrammingLanguage } from '../data-objects/programming-language';
import { Tag } from '../data-objects/tag';
import { TestSuit } from '../data-objects/create-exercise/test-suit';
import { WrittenLanguage } from '../data-objects/written-language';
import { Exercise } from '../data-objects/create-exercise/exercise';
import { ExerciseVersion } from '../data-objects/create-exercise/exercise-version';
import { ExerciseLanguage } from '../data-objects/create-exercise/exercise-language';
import { ExerciseHeader } from '../data-objects/create-exercise/exercise-header';
import { ExerciseBody } from '../data-objects/create-exercise/exercise-body';
import { TestCase } from '../data-objects/create-exercise/test-case';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  languages: string[] = ["German", "English"];
  programmingLangs: string[] = ["C#", "Java", "Python", "..."];
  viewSelected: string = "list";
  exerciseList: Exercise[];

  ngOnInit() {
    this.createDummyExerciseList();
  }

  languageDropdown() {
    document.getElementById("languageDropdown").classList.toggle("show");
    document.getElementById("languageDropdown").onmouseleave = function close() {
      document.getElementById("languageDropdown").classList.toggle("show", false);
    }
  }

  programmingDropdown() {
    document.getElementById("programmingDropdown").classList.toggle("show");
    document.getElementById("programmingDropdown").onmouseleave = function close() {
      document.getElementById("programmingDropdown").classList.toggle("show", false);
    }
  }

  selectView(view: string) {
    this.viewSelected = view;
  }

  // ToDo: remove once data is loaded from db
  createDummyExerciseList() {
    this.exerciseList = [];

    for (let i = 0; i < 20; i++) {
      let idx = i + 1;
      let exercise = this.createDummyExercise(idx);

      this.exerciseList.push(exercise);
    }
  }

  createDummyExercise(idx: number): Exercise {
    let exercise = new Exercise();

    exercise.title = "Exercise " + idx.toString();
    exercise.created = new Date();

    let user = new Author();
    user.name = "if18b133";

    exercise.user = user;

    exercise.exerciseTagList = [];
    for (let i = 0; i < 3; i++) {
      let tag = new Tag();
      tag.name = "Tag " + i.toString();

      exercise.exerciseTagList.push(tag);
    }

    exercise.exerciseVersionList = [];

    let exerciseVersion = new ExerciseVersion();
    exerciseVersion.creatorDifficulty = 2;
    exerciseVersion.creatorRating = 4;
    exerciseVersion.lasModified = new Date();
    exerciseVersion.versionNumber = 1;
    exerciseVersion.exerciseLanguageList = [];

    let exerciseLanguage = new ExerciseLanguage();

    exerciseLanguage.writtenLanguage = new WrittenLanguage();
    exerciseLanguage.writtenLanguage.name = "English";

    exerciseLanguage.exerciseHeader = new ExerciseHeader();
    exerciseLanguage.exerciseHeader.fullTitle = "Full Title " + idx.toString();
    exerciseLanguage.exerciseHeader.shortTitle = "T " + idx.toString();
    exerciseLanguage.exerciseHeader.introduction = "This is an example introduction.";

    exerciseLanguage.exerciseBody = new ExerciseBody();
    exerciseLanguage.exerciseBody.description = "This is an example description for a specific programming language";
    exerciseLanguage.exerciseBody.example = "This could be your example for the exercise";
    exerciseLanguage.exerciseBody.hint = "This could be a hint for your exercise";

    exerciseLanguage.exerciseBody.programmingLanguage = new ProgrammingLanguage();
    exerciseLanguage.exerciseBody.programmingLanguage.name = "C#";

    exerciseLanguage.exerciseBody.testSuit = new TestSuit();
    exerciseLanguage.exerciseBody.testSuit.complexity = 3;
    exerciseLanguage.exerciseBody.testSuit.prefill = "Here could be the prefill of your test suit";
    exerciseLanguage.exerciseBody.testSuit.questionType = "Quiz";
    exerciseLanguage.exerciseBody.testSuit.solution = "This could be the solution for this test suit";
    exerciseLanguage.exerciseBody.testSuit.testCaseList = [];

    for (let i = 0; i < 5; i++) {
      let testCase = new TestCase();
      testCase.additionalData = "This is some additional Data for this specific Test Case";
      testCase.description = "This is the description for this specific Test Case";
      testCase.expectedOutput = "Here should be your expected Output for this Test Case";
      testCase.points = 2;
      testCase.standardInput = "Here should be the standard Input for this Test Case";
      testCase.orderUsed = 1;

      exerciseLanguage.exerciseBody.testSuit.testCaseList.push(testCase);
    }

    exerciseVersion.exerciseLanguageList.push(exerciseLanguage);
    exercise.exerciseVersionList.push(exerciseVersion);

    return exercise;
  }
}
