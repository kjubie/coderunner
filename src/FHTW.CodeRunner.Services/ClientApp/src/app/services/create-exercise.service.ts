import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';

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
  prepareExercise(): Observable<HttpResponse<Object>> {
    return this.http.get<HttpResponse<PrepareCreateExercise>>(this.prepareExerciseUrl, { observe: 'response' }).pipe(
      tap(_ => console.log("languages and question types fetched from db")),
      catchError(this.handleError<HttpResponse<PrepareCreateExercise>>('prepareExercise'))
    );
  }

  // POST Request -> Save new Exercise to DB
  saveExercise(exercise: Exercise): Observable<HttpResponse<any>> {
    return this.http.post<HttpResponse<Exercise>>(this.createExerciseUrl, exercise, { observe: 'response' as 'body' })
      .pipe(
        tap(_ => console.log("exercise saved to database")),
        catchError(this.handleError<HttpResponse<Exercise>>('saveExercise'))
      );
  }

  // POST Request -> Save new Exercise to DB
  saveTempExercise(exercise: Exercise): Observable<HttpResponse<any>>{
    return this.http.post<HttpResponse<Exercise>>(this.createTempExerciseUrl, exercise, { observe: 'response' as 'body' })
      .pipe(
        tap(_ => console.log("exercise saved to database")),
        catchError(this.handleError<HttpResponse<Exercise>>('saveExercise'))
      );
  }

  // GET Request -> get complete exercise from DB
  getExercise(idx: number): Observable<HttpResponse<Object>> {
    let getExerciseUrl = "https://localhost:5001/api/exercise/" + idx.toString();
    return this.http.get<HttpResponse<Exercise>>(getExerciseUrl, { observe: 'response' }).pipe(
      tap(resp => console.log(resp)),
      catchError(this.handleError<HttpResponse<Exercise>>('getExercise'))
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