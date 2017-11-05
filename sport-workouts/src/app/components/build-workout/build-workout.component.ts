import { Component, OnInit, ViewChild, Input } from '@angular/core';
import {Router, ActivatedRoute, Params} from '@angular/router';
import {Exercise} from "app/models/exercise";
import { DataServiceService } from "app/services/data-service.service";
import { MuscleGroup } from "app/models/muscle-group";
import { Workout } from "app/models/workout";
import { WorkoutDay} from "app/models/workout-day";
import {ExerciseComponent} from 'app/components/exercise/exercise.component';


@Component({
  selector: 'app-build-workout',
  templateUrl: './build-workout.component.html',
  styleUrls: ['./build-workout.component.css'],
  providers: [DataServiceService]
})
export class BuildWorkoutComponent implements OnInit {
 
  muscleGroups : MuscleGroup[];
  checkedArray : boolean[] = [];
  workout : Workout;

  urlParam : any = null;
  isLoading: boolean = false;

  constructor(private dataService: DataServiceService, private router : Router, private activatedRoute: ActivatedRoute) { }

   loadMuscleGroupsList(){
      this.dataService.getMuscleGroups().then(arr => {
       this.muscleGroups = arr;
       this.initialiseMuscleGroupsBooleanArray();
       this.loadWorkoutData();
      },
      err => {
        if (err.status === 401) {
        this.router.navigate(['/login']);
        }
    });
    } 

    initialiseMuscleGroupsBooleanArray(){
      for (var i = 0; i < this.muscleGroups.length; i++){
        this.checkedArray.push(false);
      }

    }

    setUpCheckBoxes(){
        if (this.urlParam == "new"){
        return;
      }

      var groups : MuscleGroup[] = this.workout.muscleGroups;
      
      for (var i = 0; i < this.muscleGroups.length; i++){
        if (groups == null)
          return;
        for (var j = 0; j < groups.length; j++){
          if (this.muscleGroups[i].muscleGroupId == groups[j].muscleGroupId){
            this.checkedArray[i] = true;
          }
        }
      }
    }

  remove(exerciseIndex : any){
    if (exerciseIndex > -1) {
      
    this.workout.exercises.splice(exerciseIndex, 1);
    console.log(this.workout);
    }
  }

  addExercise(item : Exercise){
    if (!this.contains(item)){
      this.workout.exercises.push(item);
    }
  }

  contains(item : Exercise) : boolean{
    var exists = false;
    this.workout.exercises.forEach(ex => {
      if (ex.exerciseId == item.exerciseId){
        exists = true;
      }
    })
    return exists;
  }

  selectMuscleGroup(selected : MuscleGroup){
    this.child.transferInfo(selected);
  }

  ngOnInit() {
    this.isLoading = true; 
    this.loadMuscleGroupsList();
  }

  loadWorkoutData(){
    this.activatedRoute.params.subscribe((params: Params) => {
      this.urlParam = params['id'];

      if (this.urlParam == "new"){    // jeigu kuriamas naujas workout
        this.workout = new Workout(); // cia reikia pagamint tuscia klases objecta ir turetu viskas veikt :D
        this.workout.muscleGroups = [];
        this.workout.exercises = [];
        this.workout.workoutDays = [];
        
        this.workout.workoutDays.push({
          workoutDayId: null,
          workoutDayMonthWeek: 0,
          workoutDayWeekDay: 0
        });
      }else{   // jeigu redaguojamas esamas workout         
        this.getWorkout(this.urlParam); 
      }
      this.isLoading = false;      
    }); 
  }

  getWorkout(id : number){
    this.dataService.getWorkout(id).then(w => {
      this.workout = w;
      this.setUpCheckBoxes();
      //console.log(this.workout);
      //this.exercises = this.workout.exercises;
      //this.muscleGroups = this.workout.muscleGroups;
      //this.workoutDays.length = 1;
    });
  }

  @ViewChild(ExerciseComponent)
  private child: ExerciseComponent;

  addWorkoutDay() {

   this.workout.workoutDays.push({
     workoutDayId: null,
     workoutDayMonthWeek: 0,
     workoutDayWeekDay: 0
   });
  }

   removeWorkoutDay(i: number) {  
        this.workout.workoutDays.splice(i,1);
    }

    updateMuscleGroups(){
      this.workout.muscleGroups = [];
      for (var i = 0; i < this.checkedArray.length; i++){
      if (this.checkedArray[i]){
        var checked : MuscleGroup = this.muscleGroups[i];
        this.workout.muscleGroups.push(checked);
      }
     }
    }

    save(){
       this.updateMuscleGroups();
      this.activatedRoute.params.subscribe((params: Params) => {
        this.urlParam = params['id'];
        if (this.urlParam == "new"){  
          this.dataService.addWorkout(this.workout);
        }
        else {
          this.dataService.updateWorkout(this.workout);
        }
      });
     this.router.navigate(['/my-workouts']);
    //  console.log(this.workout);
  }

}



