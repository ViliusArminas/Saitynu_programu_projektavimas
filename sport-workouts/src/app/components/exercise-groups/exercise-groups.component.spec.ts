import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseGroupsComponent } from './exercise-groups.component';

describe('ExerciseGroupsComponent', () => {
  let component: ExerciseGroupsComponent;
  let fixture: ComponentFixture<ExerciseGroupsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExerciseGroupsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExerciseGroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
