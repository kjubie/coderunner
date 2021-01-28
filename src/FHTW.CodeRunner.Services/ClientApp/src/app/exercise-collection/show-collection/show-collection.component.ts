import { Component, OnInit } from '@angular/core';
import { CollectionDataService } from '../../services/exercise-collection.data.service';
import { CreateExerciseService } from '../../services/create-exercise.service';
import { Router } from '@angular/router';
import { ShowCollection } from 'src/app/data-objects/exercise-collection/show-collection';


@Component({
  selector: 'app-show-collection',
  templateUrl: './show-collection.component.html',
  styleUrls: ['../exercise-collection.component.css']
})
export class ShowCollectionComponent implements OnInit{
  
  showCollection: ShowCollection = new ShowCollection();
  showHeadDiv = true;

  constructor(
    private collectionDataService: CollectionDataService,
    private router: Router
    ) {}
  
  ngOnInit() {
    this.showCollection = this.collectionDataService.collectionToShow;
  }

  collapseList(listName: string) {
    if (listName === 'headDiv') {
      this.showHeadDiv = !this.showHeadDiv;
      if (this.showHeadDiv) {
          document.getElementById('arrowHeadList').classList.remove("right");
          document.getElementById('arrowHeadList').classList.add("down");
      }
      else {
          document.getElementById('arrowHeadList').classList.remove("down");
          document.getElementById('arrowHeadList').classList.add("right");
      }
    }
  }

  done() {
    this.router.navigate(['/']);
  }
}
