import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { ExerciseExport } from "../data-objects/exercise-export";

@Injectable({ providedIn: 'root' })
export class ExerciseExportService {
    private getAllExercisesUrl = "https://localhost:5001/api/export/exercise";

    constructor(
        private http: HttpClient,
    ) { }

    // POST exercise for export
    exportExercise(exercise: ExerciseExport): Observable<ExerciseExport> {
        return this.http.post<ExerciseExport>(this.getAllExercisesUrl, exercise).pipe(
            tap(_ => console.log('exercise was exported')),
            catchError(this.handleError<ExerciseExport>('exportExercise'))
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