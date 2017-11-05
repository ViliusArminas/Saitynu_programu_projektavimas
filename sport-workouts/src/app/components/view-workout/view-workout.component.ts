import { Component, OnInit } from '@angular/core';
import { DataServiceService } from "app/services/data-service.service";
import { Workout } from "app/models/workout";
import { Router, ActivatedRoute, Params } from "@angular/router";


@Component({
  selector: 'app-view-workout',
  templateUrl: './view-workout.component.html',
  styleUrls: ['./view-workout.component.css'],
  providers: [DataServiceService]
})
export class ViewWorkoutComponent implements OnInit {
 
  workout: Workout;
  isLoading: boolean = false;
  urlParam : any = null;

  constructor(private dataService: DataServiceService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
     this.isLoading = true; 
    this.loadWorkoutData();
  }

  edit(workout : Workout){
    this.router.navigate(['/build-workout/' + workout.workoutId]);
  }

  getWorkout(id : number){
    this.dataService.getWorkout(id).then(w => {
      this.workout = w;
      this.isLoading = false;  
    },
    err => {
      if (err.status === 401) {
      this.router.navigate(['/login']);
      }
  });
  }

loadWorkoutData(){
    this.activatedRoute.params.subscribe((params: Params) => {
      this.urlParam = params['id'];
      this.getWorkout(this.urlParam);   
    });
  }

}
