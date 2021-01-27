import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { CollectionHome } from "../data-objects/collection-home";
import { ExerciseHome } from "../data-objects/exercise-home";
import { SearchFilter } from "../data-objects/search-filter";

@Injectable({ providedIn: 'root' })
export class ExerciseListHomeService {
    private getAllExercisesUrl = "https://localhost:5001/api/exercise/minimal";
    private getAllCollectionsUrl = "https://localhost:5001/api/collection/minimal";
    private searchFilterUrl = "https://localhost:5001/api/exercise/search";

    constructor(
        private http: HttpClient,
    ) { }

    // GET all exercies from db (short)
    getAllExercies(): Observable<ExerciseHome[]> {
        return this.http.get<ExerciseHome[]>(this.getAllExercisesUrl).pipe(
            tap(_ => console.log('fetched all exercises from db')),
            catchError(this.handleError<ExerciseHome[]>('getAllExercies'))
        );
    }

    // GET all collections from db (minimal)
    getAllCollections(): Observable<CollectionHome[]> {
      return this.http.get<CollectionHome[]>(this.getAllCollectionsUrl).pipe(
        tap(_ => console.log('fetched all collections from db')),
        catchError(this.handleError<CollectionHome[]>('getAllCollections'))
      );
    }

    search(searchFilter: SearchFilter): Observable<ExerciseHome[]> {
      return this.http.post<ExerciseHome[]>(this.searchFilterUrl, searchFilter)
      .pipe(
        tap(_ => console.log("fetched exercises from db for filter")),
        catchError(this.handleError<ExerciseHome[]>('search'))
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