import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Exercise } from "app/models/exercise";
import { DataServiceService } from 'app/services/data-service.service';
import { MuscleGroup } from "app/models/muscle-group";
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-exercise',
  templateUrl: './add-exercise.component.html',
  styleUrls: ['./add-exercise.component.css'],
  providers: [DataServiceService]
})
export class AddExerciseComponent implements OnInit {

  muscleGroups : MuscleGroup[];
  checkedArray : boolean[] = [];

  constructor(private dataService : DataServiceService,private router : Router) { }

  ngOnInit() {
    this.dataService.getMuscleGroups().then(groups =>{
      this.muscleGroups = groups;
      this.initialiseChosenGroupsBooleanArray();
    },
    err => {
      if (err.status === 401) {
      this.router.navigate(['/login']);
      }
  });
  }

  initialiseChosenGroupsBooleanArray(){
    for (var i = 0; i < this.muscleGroups.length; i++){
      this.checkedArray.push(false);
    }

    var groups : MuscleGroup[] = this.exerciseDetails.muscleGroups;
    
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

  // reiks kazkaip padaryt, kad patikrintu ar atejo naujas obj, jeigu paspaudi nauja
  // ir tada redaguoti, neatsinaujina checkboxai
  @Input()
  exerciseDetails: Exercise;

  @Output()
  saveEvent = new EventEmitter<Exercise>();

  save(){
    this.exerciseDetails.muscleGroups = [];
    for (var i = 0; i < this.checkedArray.length; i++){
      if (this.checkedArray[i]){
        var checked : MuscleGroup = this.muscleGroups[i];
        this.exerciseDetails.muscleGroups.push(checked);
      }
    }

    this.saveEvent.emit(this.exerciseDetails);
  }

  cancel(){
    this.saveEvent.emit(null);
  }
  
}
