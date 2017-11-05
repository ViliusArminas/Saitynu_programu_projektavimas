import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuildWorkoutComponent } from './build-workout.component';

describe('BuildWorkoutComponent', () => {
  let component: BuildWorkoutComponent;
  let fixture: ComponentFixture<BuildWorkoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuildWorkoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuildWorkoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
