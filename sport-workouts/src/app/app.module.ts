import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, Http, RequestOptions } from '@angular/http';
import { routes } from './app.router';
import { AlertModule } from 'ng2-bootstrap';
import { CalendarModule } from 'angular-calendar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { ReactiveFormsModule } from '@angular/forms';
import {AuthHttp, AuthConfig} from 'ng2-bearer';

import { AppComponent } from './app.component';
import { BuildWorkoutComponent } from './components/build-workout/build-workout.component';
import { MyWorkoutsComponent } from './components/my-workouts/my-workouts.component';
import { AddExerciseComponent } from './components/add-exercise/add-exercise.component';
import { ViewExerciseComponent } from './components/view-exercise/view-exercise.component';
import { WorkoutCalendarComponent } from './components/workout-calendar/workout-calendar.component';
import { ExerciseComponent } from './components/exercise/exercise.component';
import { InMemoryDataService } from "app/services/in-memory-data.service";
import { ExerciseGroupsComponent } from './components/exercise-groups/exercise-groups.component';
import { WorkoutDayComponent } from './components/workout-day/workout-day.component';
import { LoginComponent } from './components/login/login.component';
import { AuthService } from "app/services/auth.service";
import { ViewWorkoutComponent } from './components/view-workout/view-workout.component';

export function authHttpServiceFactory(http: Http, options : RequestOptions){
  return new AuthHttp(new AuthConfig(), http, options);
}

@NgModule({
  declarations: [
    AppComponent,
    BuildWorkoutComponent,
    MyWorkoutsComponent,
    AddExerciseComponent,
    ViewExerciseComponent,
    WorkoutCalendarComponent,
    ExerciseComponent,
    ExerciseGroupsComponent,
    WorkoutDayComponent,
    LoginComponent,
    ViewWorkoutComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routes,
    AlertModule.forRoot(),
    CalendarModule.forRoot(),
    BrowserAnimationsModule,
     InMemoryWebApiModule.forRoot(InMemoryDataService, {
       passThruUnknownUrl : true
     })
  ],
  providers: [
    {
    provide: AuthHttp,
    useFactory: authHttpServiceFactory,
    deps: [Http, RequestOptions]
  },
  AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
