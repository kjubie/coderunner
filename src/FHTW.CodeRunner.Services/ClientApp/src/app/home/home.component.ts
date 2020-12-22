import { Component, OnInit } from '@angular/core';
import { ExerciseHome } from '../data-objects/exercise-home';
import { ExerciseListHomeService } from '../services/exercise-list-home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  languages: string[] = ["German", "English"];
  programmingLangs: string[] = ["C#", "Java", "Python", "..."];
  viewSelected: string = "list";
  exerciseList: ExerciseHome[];

  constructor(private exerciseListHomeService: ExerciseListHomeService) {}

  ngOnInit() {
    this.exerciseListHomeService.getAllExercies().subscribe(this.loadAllExercisesObserver);
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

  loadAllExercisesObserver = {
    next: x => { this.exerciseList = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      console.log(this.exerciseList);
    }
  }
}
