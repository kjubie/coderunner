import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ExerciseExport } from '../data-objects/exercise-export';
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
  selectedExercise: ExerciseHome;
  exerciseForExport: ExerciseExport = new ExerciseExport();

  constructor(private exerciseListHomeService: ExerciseListHomeService, private modalService: NgbModal) {}

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

  exportSingleExercise(idx: number, modalContent) {
    console.log('Export a Single exercise (idx: ' + idx + ')');
    this.selectedExercise = this.exerciseList[idx];
    
    // set needed data
    this.exerciseForExport.id = this.selectedExercise.id;
    this.exerciseForExport.title = this.selectedExercise.title;
    this.exerciseForExport.user = this.selectedExercise.user;
    this.exerciseForExport.tagList = this.selectedExercise.tagList;

    // open Modal for exercise
    this.modalService.open(modalContent, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      console.log('Closed with ' + result);
      console.log('You can export the exercise now...');
      console.log(this.exerciseForExport);
      // ToDo: add export functionality
    }, (reason) => {
      console.log('Dismissed ' + this.getDismissReason(reason));
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
