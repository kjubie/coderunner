import { Injectable } from '@angular/core';
import { ExerciseHome } from '../data-objects/exercise-home';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from "rxjs/operators";
import { Collection } from '../data-objects/exercise-collection/collection';
import { ImportCollection } from '../data-objects/import-collection/import-collection';

@Injectable()
export class CollectionDataService {
    sharedExerciseList: ExerciseHome[] = [];
    exerciseCounter: number = 0;

    private createCollectionUrl = "https://localhost:5001/api/collection";
    private importCollectionUrl = "https://localhost:5001/api/import/collection";

  
    constructor(
      private http: HttpClient,
    ) { }

    increaseExerciseCounter() {
      this.exerciseCounter += 1;
    }

    decreaseExerciseCounter() {
      this.exerciseCounter -= 1;
    }

    saveCollection(collection: Collection): Observable<Collection> {
      return this.http.post<Collection>(this.createCollectionUrl, collection)
        .pipe(
          tap((createdCollection: Collection) => console.log("collection saved to database: " + createdCollection)),
          catchError(this.handleError<Collection>('saveCollection', collection))
      );
    }

    importCollection(importCollection): Observable<ImportCollection> {
      return this.http.post<ImportCollection>(this.importCollectionUrl, importCollection)
        .pipe(
          tap((createdCollection: ImportCollection) => console.log("collection saved to database: " + createdCollection)),
          catchError(this.handleError<ImportCollection>('saveCollection', importCollection))
      );      
    }

    /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error); // log to console

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}