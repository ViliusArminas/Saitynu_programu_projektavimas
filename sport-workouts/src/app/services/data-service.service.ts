import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Http, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Exercise } from "app/models/exercise";
import { Workout } from "app/models/workout";
import {MuscleGroup} from 'app/models/muscle-group';
import { environment } from 'environments/environment';

@Injectable()
export class DataServiceService {
  delayTimeSec: number = 1000;
  backEndUrl = environment.backEndPoint;

  constructor(private http: Http) { }



   getExercises(): Promise<Exercise[]> {
    let authToken = localStorage.getItem('access_token');
    let headers = new Headers({ 'Accept': 'application/json' });
    headers.append('Authorization', `Bearer ${authToken}`);
    let options = new RequestOptions({ headers: headers });
    return this.http.get(this.backEndUrl + '/api/exer', options)
      .delay(this.delayTimeSec)
      .toPromise()
      .then(response => {
        return response.json() as Exercise[];
      });   
  }

  addExercise(exercises: Exercise): Promise<Exercise> {
    let authToken = localStorage.getItem('access_token');
    let headers = new Headers({ 'Accept': 'application/json' });
    headers.append('Authorization', `Bearer ${authToken}`);
    let options = new RequestOptions({ headers: headers });
    return this.http.post(this.backEndUrl + '/api/exer', exercises, options)
      .toPromise()
      .then(response => { 
       return response.json().data as Exercise;});   
       
  }  

  updateExercise(exercise: Exercise): Promise<Exercise> {
    let authToken = localStorage.getItem('access_token');
    let headers = new Headers({ 'Accept': 'application/json' });
    headers.append('Authorization', `Bearer ${authToken}`);
    let options = new RequestOptions({ headers: headers });
    return this.http.put(this.backEndUrl + '/api/exercises/' + exercise.exerciseId, exercise, options)
      .toPromise()
     .then(
        response => {
          console.log(response.json() as Exercise);
          return response.json() as Exercise;
        });   
  }  

  removeExercise(exercise : Exercise): Promise<void> {
    let authToken = localStorage.getItem('access_token');
    let headers = new Headers({ 'Accept': 'application/json' });
    headers.append('Authorization', `Bearer ${authToken}`);
    let options = new RequestOptions({ headers: headers });
    return this.http.delete(this.backEndUrl + '/api/exer/delete/' + exercise.exerciseId, options)
     .toPromise()
     .then( () => null);
  }

  getExercisesByMuscleGroup(groupId : number): Promise<Exercise[]> {
    let authToken = localStorage.getItem('access_token');
    let headers = new Headers({ 'Accept': 'application/json' });
    headers.append('Authorization', `Bearer ${authToken}`);
    let options = new RequestOptions({ headers: headers });
    return this.http.get(this.backEndUrl + '/api/exer/' + groupId, options)
      .toPromise()
      .then(response => {
        return response.json() as Exercise[];
      });     
  }

  //----------------------------------------------------------------------
  // muscle group service

  getMuscleGroups(): Promise<MuscleGroup[]> {
    let authToken = localStorage.getItem('access_token');
    let headers = new Headers({ 'Accept': 'application/json' });
    headers.append('Authorization', `Bearer ${authToken}`);
    let options = new RequestOptions({ headers: headers });
    return this.http.get(this.backEndUrl + '/api/musclegroups', options)
      .toPromise()
      .then(response => {
        //console.log(response);
        return response.json() as MuscleGroup[];
      });    
  }
  
  // workouts service

getWorkouts(): Promise<Workout[]> {
  let authToken = localStorage.getItem('access_token');
  let headers = new Headers({ 'Accept': 'application/json' });
  headers.append('Authorization', `Bearer ${authToken}`);
  let options = new RequestOptions({ headers: headers });
    return this.http.get(this.backEndUrl + '/api/workouts', options)
      .toPromise()
      .then(response => {
        //console.log(response);
        return response.json() as Workout[];
      });   
}

getWorkout(id : number): Promise<Workout> {
  let authToken = localStorage.getItem('access_token');
  let headers = new Headers({ 'Accept': 'application/json' });
  headers.append('Authorization', `Bearer ${authToken}`);
  let options = new RequestOptions({ headers: headers });
    return this.http.get(this.backEndUrl + '/api/workouts/' + id, options)
      .toPromise()
      .then(response => {
        return response.json() as Workout;
      });    
}

 addWorkout(workout: Workout): Promise<Workout> {
  let authToken = localStorage.getItem('access_token');
  let headers = new Headers({ 'Accept': 'application/json' });
  headers.append('Authorization', `Bearer ${authToken}`);
  let options = new RequestOptions({ headers: headers });
    return this.http.post(this.backEndUrl + '/api/workouts', workout, options)
      .toPromise()
      .then(response => {
       console.log(response);
        return response.json().data as Workout;
      });    
  }  

updateWorkout(workout: Workout): Promise<Workout> {
  let authToken = localStorage.getItem('access_token');
  let headers = new Headers({ 'Accept': 'application/json' });
  headers.append('Authorization', `Bearer ${authToken}`);
  let options = new RequestOptions({ headers: headers });
    return this.http.put(this.backEndUrl + '/api/workouts/update/' + workout.workoutId, workout, options)
      .toPromise()
      .then(response => {
       console.log(response);
        return response.json().data as Workout;
      });     
  }  

   removeWorkout(workout : Workout): Promise<void> {
    return this.http.delete('/api/workouts/' + workout.workoutId)
     .toPromise()
     .then( () => null);
  }


}
