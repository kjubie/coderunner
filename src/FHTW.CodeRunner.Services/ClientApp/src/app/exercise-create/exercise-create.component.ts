import { Component, OnInit, NgModule } from '@angular/core';
import { Exercise } from '../data-objects/exercise';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-exercise-create',
  templateUrl: './exercise-create.component.html',
  styleUrls: ['./exercise-create.component.css']
})
@NgModule({
  declarations: [
	AppComponent
  ],
  imports: [
	BrowserModule,
	FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class ExerciseCreateComponent implements OnInit {

  tabSelected: string = "general";
  exercise: Exercise;
  
  setTab(tab: string) {
    this.tabSelected = tab;
  }

  ngOnInit() {
    this.exercise = new Exercise();
    this.exercise.created = new Date();
  }
}
