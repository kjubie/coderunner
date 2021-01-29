import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Author } from '../data-objects/author';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';
import { ImportCollection } from '../data-objects/import-collection/import-collection';
import { WrittenLanguage } from '../data-objects/written-language';
import { CreateExerciseService } from '../services/create-exercise.service';
import { CollectionDataService } from '../services/exercise-collection.data.service';
import * as $ from "jquery";
import "bootstrap";

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.css']
})

export class ImportComponent implements OnInit {

  errorMsg: string;
  httpResponse: HttpResponse<Object>;
  supportedFileTypes = ['xml'];
  validFile = true;
  fileContent: string;
  importCollection: ImportCollection = new ImportCollection;
  writtenLangs: WrittenLanguage[];
  dataLists: PrepareCreateExercise;

  constructor(
    private collectionDataService: CollectionDataService,
    private createExerciseService: CreateExerciseService,
    private router: Router
    ) {};

  ngOnInit() {
    this.createExerciseService.prepareExercise().subscribe(this.prepareExerciseObserver);
  }

  prepareExerciseObserver = {
    next: x => { if (x != undefined) { this.dataLists = x.body; this.httpResponse = x } else { this.httpResponse = undefined }},
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      if (this.httpResponse == undefined) {
        this.errorMsg = "Unable to prepare Data!";
        $('.toast').toast('show');
      }
      else if (this.httpResponse.status == 200) {
        this.writtenLangs = this.dataLists.writtenLanguageList;
      }
    }
  }

  importCollectionObserver = {
    next: x => { if (x != undefined) { this.Import = x.body; this.httpResponse = x } else { this.httpResponse = undefined }},
    error: err => console.error('Observer got an error: ' + err),
    complete: () => {
      if (this.httpResponse == undefined) {
        this.errorMsg = "Unable to import Collection!";
        $('.toast').toast('show');
      }
      else if (this.httpResponse.status == 200) {
        console.log("Collection was saved to database")
        this.importCollection = new ImportCollection;
        this.router.navigate(['/']);
      }
    }
  }

  Import() {
    this.importCollection.base64XmlString = this.fileContent;
    this.importCollection.user = new Author();
    this.importCollection.user.id = (localStorage.getItem('user_id') !== null) ? parseInt(localStorage.getItem('user_id')) : 0;
    this.importCollection.user.name = localStorage.getItem('name');

    this.collectionDataService.importCollection(this.importCollection).subscribe(this.importCollectionObserver);
  }

  upload(files: any) {
    let file = (<HTMLInputElement>document.getElementById('fileDrop')).files.item(0);
    let fileName = file.name.split('.')[1];

    if (file && file.type) {
      if (0 > this.supportedFileTypes.indexOf(fileName)) {
        this.validFile = false;
      }
      else {
        this.validFile = true;
        let reader = new FileReader();
        reader.onload = this.handleFile.bind(this);
        reader.readAsBinaryString(file);
      }
    }
  }

  Cancel() {
    this.router.navigate(['/']);
  }

  handleFile(event) {
    var binaryString = event.target.result;
    this.fileContent = btoa(binaryString);
    console.log(this.fileContent);
  }  
}