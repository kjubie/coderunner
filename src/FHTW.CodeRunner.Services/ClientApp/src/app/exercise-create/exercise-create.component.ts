import { Component, OnInit, Output } from '@angular/core';
import { Exercise } from '../data-objects/exercise';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from '../app.component';
import { TestSuitTabComponent } from './tabs/test-suit-tab/test-suit-tab.component';

@Component({
  selector: 'app-exercise-create',
  templateUrl: './exercise-create.component.html',
  styleUrls: ['./exercise-create.component.css']
})
export class ExerciseCreateComponent implements OnInit {

  tabSelected: string = "general";
  @Output() exercise: Exercise;
  
  setTab(tab: string) {
    this.tabSelected = tab;
  }

  ngOnInit() {
    this.exercise = new Exercise();
    this.exercise.created = new Date();
  }
}
