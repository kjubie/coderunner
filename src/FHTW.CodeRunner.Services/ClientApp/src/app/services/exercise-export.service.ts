import { HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { CollectionExport } from "../data-objects/collection-export";
import { ExerciseExport } from "../data-objects/exercise-export";

@Injectable({ providedIn: 'root' })
export class ExerciseExportService {
    private exportExerciseUrl = "https://localhost:5001/api/export/exercise";
    private exportCollectionUrl = "https://localhost:5001/api/export/collection";

    constructor(
        private http: HttpClient,
    ) { }

    // POST exercise for export
    exportExercise(exercise: ExerciseExport): Observable<HttpResponse<Object>> {
      return this.http.post<HttpResponse<ExerciseExport>>(this.exportExerciseUrl, exercise, { responseType: 'text' as 'json', observe: 'response' as 'body' }).pipe(
        tap(_ => console.log('exercise was exported')),
        catchError(this.handleError<HttpResponse<ExerciseExport>>('exportExercise'))
      );
    }

    // POST collection for export
    exportCollection(collection: CollectionExport): Observable<HttpResponse<Object>> {
      return this.http.post<HttpResponse<CollectionExport>>(this.exportCollectionUrl, collection, { responseType: 'text' as 'json', observe: 'response' as 'body' }).pipe(
        tap(_ => console.log('collection was exported')),
        catchError(this.handleError<HttpResponse<CollectionExport>>('exportCollection'))
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