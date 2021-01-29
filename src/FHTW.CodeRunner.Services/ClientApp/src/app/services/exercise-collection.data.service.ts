import { Injectable } from '@angular/core';
import { ExerciseHome } from '../data-objects/exercise-home';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from "rxjs/operators";
import { Collection } from '../data-objects/exercise-collection/collection';
import { ImportCollection } from '../data-objects/import-collection/import-collection';
import { ShowCollection } from '../data-objects/exercise-collection/show-collection';

@Injectable()
export class CollectionDataService {
    sharedExerciseList: ExerciseHome[] = [];
    exerciseCounter: number = 0;
    collectionToShow: ShowCollection;

    private createCollectionUrl = "https://localhost:5001/api/collection";
    private getCollectionUrl = "https://localhost:5001/api/collection/";
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

    saveCollection(collection: Collection): Observable<HttpResponse<Object>> {
      return this.http.post<HttpResponse<Collection>>(this.createCollectionUrl, collection, { observe: 'response' as 'body' })
        .pipe(
          tap(_ => console.log("collection saved to database")),
          catchError(this.handleError<HttpResponse<Collection>>('saveCollection'))
      );
    }

    importCollection(importCollection: ImportCollection): Observable<HttpResponse<Object>> {
      return this.http.post<HttpResponse<ImportCollection>>(this.importCollectionUrl, importCollection, { observe: 'response' as 'body' })
        .pipe(
          tap(_ => console.log("collection saved to database")),
          catchError(this.handleError<HttpResponse<ImportCollection>>('saveCollection'))
      );
    }

    getCollection(id: number): Observable<HttpResponse<Object>> {
      return this.http.get<HttpResponse<ShowCollection>>(this.getCollectionUrl + id, { observe: 'response' })
      .pipe(
        tap(_ => console.log("fetched collectio to show")),
        catchError(this.handleError<HttpResponse<ShowCollection>>('getCollection'))
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