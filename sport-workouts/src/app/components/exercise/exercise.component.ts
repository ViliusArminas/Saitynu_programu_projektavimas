import { Component, OnInit, Output,  EventEmitter} from '@angular/core';
import { DataServiceService } from "app/services/data-service.service";
import { Exercise } from "app/models/exercise";
import { MuscleGroup } from "app/models/muscle-group";
import { Router } from '@angular/router';

@Component({
  selector: 'app-exercise',
  templateUrl: './exercise.component.html',
  styleUrls: ['./exercise.component.css'],
  providers: [DataServiceService]
})
export class ExerciseComponent implements OnInit {
  exercises: Exercise[];
  selectedMuscleGroup : MuscleGroup = null;
  
  isLoading: boolean = false;
  isEmpty : boolean = false; 

  constructor(private dataService: DataServiceService, private router: Router) { }

  ngOnInit() {
    this.loadList();
  }

  loadList(){
    this.isLoading = true;
    this.dataService.getMuscleGroups().then(c => {
       this.selectedMuscleGroup = c[0];
       this.loadExercises(this.selectedMuscleGroup.muscleGroupId);
    },
    err => {
      if (err.status === 401) {
      this.router.navigate(['/login']);
      }
  });
  }

  loadExercises(id : number){
    this.dataService.getExercisesByMuscleGroup(id).then(c => {
          this.exercises = c;
          this.isLoading = false;
    },
    err => {
      if (err.status === 401) {
      this.router.navigate(['/login']);
      }
  });
  }

  refreshList(){
      this.isLoading = true;
      this.loadExercises(this.selectedMuscleGroup.muscleGroupId);
    }

  @Output()
  addEvent = new EventEmitter<Exercise>(); 

  add(index : any){
    this.addEvent.emit(this.exercises[index]);
  }

  remove(exerciseIndex : any){
    if (exerciseIndex > -1) {
      this.exercises.splice(exerciseIndex, 1);
    }
  }

  transferInfo(selected : MuscleGroup){
    this.selectedMuscleGroup = selected;
    this.refreshList();
  }
  
}
