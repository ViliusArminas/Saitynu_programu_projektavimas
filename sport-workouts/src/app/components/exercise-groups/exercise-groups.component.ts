import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MuscleGroup } from "app/models/muscle-group";
import { DataServiceService } from "app/services/data-service.service";
import { Router } from '@angular/router';

@Component({
  selector: 'app-exercise-groups',
  templateUrl: './exercise-groups.component.html',
  styleUrls: ['./exercise-groups.component.css'],
  providers: [DataServiceService]
})
export class ExerciseGroupsComponent implements OnInit {

  groups : MuscleGroup[];

  constructor(private dataService : DataServiceService, private router: Router) { }

  loadMuscleGroupList(){
    this.dataService.getMuscleGroups().then(list => {
      this.groups = list;
    },
    err => {
      if (err.status === 401) {
      this.router.navigate(['/login']);
      }
  });
}


  @Output()
  selectEvent = new EventEmitter<MuscleGroup>();

  select(selected : MuscleGroup){
    this.selectEvent.emit(selected);
  }

  ngOnInit() {
    this.loadMuscleGroupList();
  }

}
