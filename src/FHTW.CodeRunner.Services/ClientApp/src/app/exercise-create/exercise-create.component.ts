import { Component, OnInit } from '@angular/core';
import { CreateExercise } from '../data-objects/create-exercise';

@Component({
  selector: 'app-exercise-create',
  templateUrl: './exercise-create.component.html',
  styleUrls: ['./exercise-create.component.css']
})
export class ExerciseCreateComponent {

  tabSelected: string = "general";
  exercise: CreateExercise;
  
  setTab(tab: string) {
    this.tabSelected = tab;
  }

  moveToNextTab(tab: string) {
    // ToDo: set data of this tab for further use
    this.setTab(tab);
  }
}
