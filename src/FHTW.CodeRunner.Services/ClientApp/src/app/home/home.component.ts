import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ExerciseExport } from '../data-objects/exercise-export';
import { ExerciseHome } from '../data-objects/exercise-home';
import { ExerciseListHomeService } from '../services/exercise-list-home.service';
import { ExerciseExportService } from '../services/exercise-export.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  viewSelected: string = "list";
  exerciseList: ExerciseHome[];
  selectedExercise: ExerciseHome;
  exerciseForExport: ExerciseExport = new ExerciseExport();
  versionInvalid = false;
  wLangInvalid = false;
  pLangInvalid = false;

  constructor(private exerciseListHomeService: ExerciseListHomeService, private modalService: NgbModal, private exportService: ExerciseExportService) {}

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

  exportExerciseObserver = {
    complete: () => {
      console.log('exercise successfully exported');
    }
  }

  exportSingleExercise(idx: number, modalContent) {
    this.selectedExercise = this.exerciseList[idx];
    
    // set needed data
    this.exerciseForExport.id = this.selectedExercise.id;
    // this.exerciseForExport.version = 0; // ToDo: remove once version is set in modal
    this.exerciseForExport.tagList = this.selectedExercise.tagList;

    // open Modal for exercise
    this.modalService.open(modalContent, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      console.log('Closed with ' + result);
    }, (reason) => {
      console.log('Dismissed ' + this.getDismissReason(reason));
    });
  
    this.resetForm();
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

  exportExercise() {
    // validate exercise
    this.versionInvalid = (this.exerciseForExport.version == undefined);
    this.wLangInvalid = (this.exerciseForExport.writtenLanguage == undefined);
    this.pLangInvalid = (this.exerciseForExport.programmingLanguage == undefined);

    if (!this.versionInvalid && !this.wLangInvalid && !this.pLangInvalid) {
      console.log('exercise is ready for export');
      console.log(this.exerciseForExport);
      this.exportService.exportExercise(this.exerciseForExport).subscribe(this.exportExerciseObserver);
      this.modalService.dismissAll('Exercise exported');
    }
    else {
      console.log('Oops, something went wrong. Needed parameters were not set...');
    }    
  }

  resetForm() {
    this.versionInvalid = false;
    this.wLangInvalid = false;
    this.pLangInvalid = false;
    this.exerciseForExport = new ExerciseExport();
  }
}
