import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import {catchError, tap} from "rxjs/operators";
import { Exercise } from '../data-objects/create-exercise/exercise';
import { PrepareCreateExercise } from '../data-objects/create-exercise/prepare-create-exercise';


@Injectable({ providedIn: 'root' })
export class CreateExerciseService {
  editExercise: Exercise;
  viewExercise: Exercise;

  private createExerciseUrl = "https://localhost:5001/api/exercise";
  private createTempExerciseUrl = "https://localhost:5001/api/exercise/temporary";
  private prepareExerciseUrl = "https://localhost:5001/api/exercise/prepare";

  constructor(private http: HttpClient) {
    this.editExercise = undefined;
    this.viewExercise = new Exercise();
  }

  // GET Request -> fetch written, programming Lang etc. for create
  prepareExercise(): Observable<PrepareCreateExercise> {
    return this.http.get<PrepareCreateExercise>(this.prepareExerciseUrl).pipe(
      tap(_ => console.log("languages and question types fetched from db")),
      catchError(this.handleError<PrepareCreateExercise>('prepareExercise'))
    );
  }

  // POST Request -> Save new Exercise to DB
  saveExercise(exercise: Exercise): Observable<Exercise> {
    return this.http.post<Exercise>(this.createExerciseUrl, exercise)
      .pipe(
        tap((createdExercise: Exercise) => console.log("exercise saved to database: " + createdExercise)),
        catchError(this.handleError<Exercise>('saveExercise', exercise))
      );
  }

  // POST Request -> Save new Exercise to DB
  saveTempExercise(exercise: Exercise): Observable<Exercise> {
    return this.http.post<Exercise>(this.createTempExerciseUrl, exercise)
      .pipe(
        tap((createdExercise: Exercise) => console.log("exercise saved to database: " + createdExercise)),
        catchError(this.handleError<Exercise>('saveExercise', exercise))
      );
  }

  // GET Request -> get complete exercise from DB
  getExercise(idx: number): Observable<Exercise> {
    let getExerciseUrl = "https://localhost:5001/api/exercise/" + idx.toString();
    return this.http.get<Exercise>(getExerciseUrl).pipe(
      tap(resp => console.log(resp)),
      catchError(this.handleError<Exercise>('getExercise'))
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