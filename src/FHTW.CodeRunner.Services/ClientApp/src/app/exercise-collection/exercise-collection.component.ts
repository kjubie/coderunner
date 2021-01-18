import { Component, Input } from '@angular/core';
import { Exercise } from '../data-objects/create-exercise/exercise';

@Component({
  selector: 'app-exercise-collection',
  templateUrl: './exercise-collection.component.html',
  styleUrls: ['./exercise-collection.component.css']
})
export class ExerciseCollectionComponent {

  @Input() collectionExerciseList: Exercise[];

  showHeadDiv = true;

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
}
