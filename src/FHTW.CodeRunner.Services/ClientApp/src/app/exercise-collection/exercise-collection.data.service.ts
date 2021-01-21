import { Injectable } from '@angular/core';
import { ExerciseHome } from '../data-objects/exercise-home';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import {catchError, tap} from "rxjs/operators";
import { Exercise } from '../data-objects/create-exercise/exercise';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';
import { Collection } from '../data-objects/exercise-collection/collection';

@Injectable()
export class CollectionDataService {
    sharedExerciseList: ExerciseHome[] = [];

    private createCollectionUrl = "https://localhost:5001/api/collection";
  
    constructor(
      private http: HttpClient,
    ) { }

    saveCollection(collection: Collection): Observable<Collection> {
        return this.http.post<Collection>(this.createCollectionUrl, collection)
            .pipe(
                tap((createdCollection: Collection) => console.log("collection saved to database: " + createdCollection)),
                catchError(this.handleError<Collection>('saveCollection', collection))
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