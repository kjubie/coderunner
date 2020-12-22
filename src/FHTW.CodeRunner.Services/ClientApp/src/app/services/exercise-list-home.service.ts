import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { ExerciseHome } from "../data-objects/exercise-home";

@Injectable({ providedIn: 'root' })
export class ExerciseListHomeService {
    private getAllExercisesUrl = "https://localhost:5001/api/exercise/short";

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