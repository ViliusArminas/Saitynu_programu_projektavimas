import { Component, OnInit, Input, ViewChild} from '@angular/core';
import { WorkoutDay } from "app/models/workout-day";

@Component({
  selector: 'app-workout-day',
  templateUrl: './workout-day.component.html',
  styleUrls: ['./workout-day.component.css']
})
export class WorkoutDayComponent implements OnInit {

@Input() 
workoutDays: WorkoutDay;


  constructor() { }

  ngOnInit() {
    //console.log(this.workoutDays);
  }



}
