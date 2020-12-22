import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import {catchError, tap} from "rxjs/operators";
import { Exercise } from '../data-objects/create-exercise/exercise';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';


@Injectable({ providedIn: 'root' })
export class CreateExerciseService {

  private createExerciseUrl = "https://localhost:5001/api/exercise";
  private prepareExerciseUrl = "https://localhost:5001/api/exercise/prepare";

  constructor(
    private http: HttpClient,
  ) { }

  // GET Request -> fetch written, programming Lang etc. for create
  prepareExercise(): Observable<PrepareCreateExercise> {
    return this.http.get<PrepareCreateExercise>(this.prepareExerciseUrl/*, this.requestOptions*/).pipe(
      tap(_ => console.log("languages and question types fetched from db")),
      catchError(this.handleError<PrepareCreateExercise>('prepareExercise'))
    );
    
    
  }

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