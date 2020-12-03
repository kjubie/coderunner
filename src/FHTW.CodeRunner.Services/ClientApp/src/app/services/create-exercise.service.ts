import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import {catchError, tap} from "rxjs/operators";
import { Exercise } from '../data-objects/create-exercise/exercise';


@Injectable({ providedIn: 'root' })
export class CreateExerciseService {

  private createExerciseUrl = "https://localhost:5001/api/exercise";

  constructor(
    private http: HttpClient,
  ) { }

  // ToDo:
  // POST Request -> Save new Exercise to DB
  saveExercise(exercise: Exercise): Observable<Exercise> {
    return this.http.post<Exercise>(this.createExerciseUrl, exercise)
      .pipe(
        tap((createdExercise: Exercise) => console.log("exercise saved to database: " + createdExercise)),
        catchError(this.handleError<Exercise>('saveExercise', exercise))
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