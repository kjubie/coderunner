import { HttpClient, HttpResponse } from "@angular/common/http";
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
    getAllExercies(): Observable<HttpResponse<Object>> {
        return this.http.get<HttpResponse<ExerciseHome[]>>(this.getAllExercisesUrl, { observe: 'response' }).pipe(
            tap(_ => console.log('fetched all exercises from db')),
            catchError(this.handleError<HttpResponse<ExerciseHome[]>>('getAllExercies'))
        );
    }

    // GET all collections from db (minimal)
    getAllCollections(): Observable<HttpResponse<Object>> {
      return this.http.get<HttpResponse<CollectionHome[]>>(this.getAllCollectionsUrl, { observe: 'response' }).pipe(
        tap(resp => {
          console.log(resp);
          console.log('fetched all collections from db')
        }),
        catchError(this.handleError<HttpResponse<CollectionHome[]>>('getAllCollections'))
      );
    }

    search(searchFilter: SearchFilter): Observable<HttpResponse<Object>> {
      console.log(searchFilter);
      return this.http.post<HttpResponse<ExerciseHome[]>>(this.searchFilterUrl, searchFilter, { observe: 'response' as 'body' })
      .pipe(
        tap(_ => console.log("fetched exercises from db for filter")),
        catchError(this.handleError<HttpResponse<ExerciseHome[]>>('search'))
      ); 
    }

    searchCollection(searchFilter: SearchFilter): Observable<HttpResponse<Object>> {
      return this.http.post<HttpResponse<CollectionHome[]>>(this.searchFilterUrl, searchFilter, { observe: 'response' as 'body' })
      .pipe(
        tap(_ => console.log("fetched collections from db for filter")),
        catchError(this.handleError<HttpResponse<CollectionHome[]>>('search'))
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