import { Component, NgModule, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ExerciseExport } from '../data-objects/exercise-export';
import { ExerciseHome } from '../data-objects/exercise-home';
import { ExerciseListHomeService } from '../services/exercise-list-home.service';
import { ExerciseExportService } from '../services/exercise-export.service';
import { CollectionDataService } from '../services/exercise-collection.data.service';
import { CollectionHome } from '../data-objects/collection-home';
import { CollectionExport } from '../data-objects/collection-export';
import { SearchFilter } from '../data-objects/search-filter';
import { CreateExerciseService } from '../services/create-exercise.service';
import { Exercise } from '../data-objects/create-exercise/exercise';
import { Router, RouterModule, Routes } from '@angular/router';
import { ExerciseCreateComponent } from '../exercise-create/exercise-create.component';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';


const routes: Routes = [
  { path: 'exercise-create', component: ExerciseCreateComponent },
];
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class HomeComponent implements OnInit {

  viewSelected: string = "list";
  xmlExportString: string;
  searchFilter: SearchFilter = new SearchFilter();
  exerciseList: ExerciseHome[];
  collectionList: CollectionHome[];
  selectedExercise: ExerciseHome;
  selectedCollection: CollectionHome;
  exerciseForExport: ExerciseExport = new ExerciseExport();
  collectionForExport: CollectionExport = new CollectionExport();
  exerciseToEdit: Exercise = new Exercise();
  languageData: PrepareCreateExercise;
  languages: string[] = [];
  programmingLangs: string[] = [];

  versionInvalid = false;
  wLangInvalid = false;
  pLangInvalid = false;

  showExercises = true;

  constructor(private exerciseListHomeService: ExerciseListHomeService, private modalService: NgbModal, private exportService: ExerciseExportService, private collectionDataService: CollectionDataService, private createExerciseService: CreateExerciseService, private router: Router) {}

  ngOnInit() {
    this.createExerciseService.prepareExercise().subscribe(this.prepareObserver);
    this.exerciseListHomeService.getAllExercies().subscribe(this.loadAllExercisesObserver);
    this.exerciseListHomeService.getAllCollections().subscribe(this.loadAllCollectionsObserver);
    this.createExerciseService.editExercise = undefined;
  }

  selectView(view: string) {
    this.viewSelected = view;
  }

  prepareObserver = {
    next: x => { this.languageData = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      this.languageData.writtenLanguageList.forEach(lang => {
        this.languages.push(lang.name);
      });

      this.languageData.programmingLanguageList.forEach(lang => {
        this.programmingLangs.push(lang.name);
      });
    }
  }

  loadAllExercisesObserver = {
    next: x => { this.exerciseList = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      console.log(this.exerciseList);
    }
  }

  loadAllCollectionsObserver = {
    next: x => { this.collectionList = x.body; },
    error: err => { console.log('Observer got an error: ' + err); },
    complete: () => {
      console.log(this.collectionList);
    }
  }

  exportExerciseObserver = {
    next: x => { this.xmlExportString = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      console.log('download xml file');
      this.downloadXMLFile('ExportExercise');
    }
  }

  exportCollectionObserver = {
    next: x => { this.xmlExportString = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      console.log('download xml file');
      console.log(this.xmlExportString);
      this.downloadXMLFile('ExportCollection');
    }
  }

  searchFilterObserver = {
    next: x => { this.exerciseList = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      console.log(this.exerciseList);
    }
  }

  searchCollectionFilterObserver = {
    next: x => { this.collectionList = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      console.log(this.collectionList);
    }
  }

  getExerciseObserver = {
    next: x => { this.exerciseToEdit = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      this.createExerciseService.editExercise = this.exerciseToEdit;

      this.router.navigate(['/exercise-create']);
    }
  }

  viewExerciseObserver = {
    next: x => { this.createExerciseService.viewExercise = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      this.router.navigate(['/exercise-view']);
    }
  }

  viewCollectionObserver = {
    next: x => { this.collectionDataService.showCollection = x },
    error: err => { console.log('Observer got an error: ' + err) },
    complete: () => {
      this.router.navigate(['/show-collection']);
    }
  }

  exportSingleExercise(idx: number, modalContent) {
    this.selectedExercise = this.exerciseList[idx];

    // open Modal for exercise
    this.modalService.open(modalContent, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      console.log('Closed with ' + result);
    }, (reason) => {
      console.log('Dismissed ' + this.getDismissReason(reason));
    });

    this.resetForm();
  }

  exportSingleCollection(idx: number, modalContent) {
    this.selectedCollection = this.collectionList[idx];

    // open Modal for collection
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
      this.exerciseForExport.id = this.selectedExercise.id;
      console.log('exercise is ready for export');
      console.log(this.exerciseForExport);
      this.exportService.exportExercise(this.exerciseForExport).subscribe(this.exportExerciseObserver);
      this.modalService.dismissAll('Exercise exported');
    }
    else {
      console.log('Oops, something went wrong. Needed parameters were not set...');
    }    
  }

  exportCollection() {
    // validate modal
    this.wLangInvalid = (this.collectionForExport.writtenLanguage == undefined);

    if (!this.wLangInvalid) {
      this.collectionForExport.id = this.selectedCollection.id;
      console.log('collection is ready for export');
      console.log(this.collectionForExport);
      this.exportService.exportCollection(this.collectionForExport).subscribe(this.exportCollectionObserver);
      this.modalService.dismissAll('Collection exported');
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
    this.collectionForExport = new CollectionExport();
  }

  private downloadXMLFile(name: string) {
    const filename = name + '.xml';
    const blob = new Blob([this.xmlExportString], {type: 'text/xml'});
    if (window.navigator && window.navigator.msSaveOrOpenBlob) { // IE
      window.navigator.msSaveOrOpenBlob(blob, filename);
      window.navigator.msSaveOrOpenBlob(blob, filename);
    } else { //Chrome & Firefox
      const a = document.createElement('a');
      const url = window.URL.createObjectURL(blob);
      a.href = url;
      a.download = filename;
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    }
  }

  addExerciseToCollection(idx: number) {
    this.collectionDataService.sharedExerciseList.push(this.exerciseList[idx]);
    this.collectionDataService.increaseExerciseCounter();
  }

  editExercise(idx: number) {
    idx += 1;
    this.createExerciseService.getExercise(idx).subscribe(this.getExerciseObserver);
  }

  viewExercise(idx: number) {
    idx += 1;
    this.createExerciseService.getExercise(idx).subscribe(this.viewExerciseObserver);
  }

  viewCollection(idx: number) {
    this.collectionDataService.showCollection(this.collectionList[idx].id).subscribe(this.viewCollectionObserver);
  }

  switchLists() {
    this.showExercises = !this.showExercises;
  }

  setFilterLang(lang: string) {
    this.searchFilter.writtenLanguage = lang;
  }

  setFilterPLang(lang: string) {
    this.searchFilter.programmingLanguage = lang;
  }

  search() {
    if (this.showExercises) {
      this.exerciseListHomeService.search(this.searchFilter).subscribe(this.searchFilterObserver);
    } else {
      this.exerciseListHomeService.searchCollection(this.searchFilter).subscribe(this.searchCollectionFilterObserver);
    }
  }

  resetFilter() {
    this.searchFilter.programmingLanguage = null;
    this.searchFilter.writtenLanguage = null;
    this.searchFilter.searchTerm = null;

    this.search();
  }
}
