import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ExerciseExport } from '../data-objects/exercise-export';
import { ExerciseHome } from '../data-objects/exercise-home';
import { ExerciseListHomeService } from '../services/exercise-list-home.service';
import { ExerciseExportService } from '../services/exercise-export.service';
import { CollectionDataService } from '../services/exercise-collection.data.service';
import { CollectionHome } from '../data-objects/collection-home';
import { CollectionExport } from '../data-objects/collection-export';
import { SearchFilter } from '../data-objects/search-filter';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
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
  languages = ['English', 'German'];
  programmingLangs = ['C#', 'Java'];

  versionInvalid = false;
  wLangInvalid = false;
  pLangInvalid = false;

  showExercises = true;

  constructor(private exerciseListHomeService: ExerciseListHomeService, private modalService: NgbModal, private exportService: ExerciseExportService, private collectionDataService: CollectionDataService) {}

  ngOnInit() {
    this.exerciseListHomeService.getAllExercies().subscribe(this.loadAllExercisesObserver);
    this.exerciseListHomeService.getAllCollections().subscribe(this.loadAllCollectionsObserver);
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

  loadAllCollectionsObserver = {
    next: x => { this.collectionList = x },
    error: err => { console.log('Observer got an error: ' + err) },
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

  switchLists() {
    this.showExercises = !this.showExercises;
  }

  search() {
    if (this.showExercises) {
      this.exerciseListHomeService.search(this.searchFilter).subscribe(this.searchFilterObserver);
    } else {
      this.exerciseListHomeService.searchCollection(this.searchFilter).subscribe(this.searchCollectionFilterObserver);
    }
  }
}
