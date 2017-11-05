import { MuscleGroup } from 'app/models/muscle-group'

export class Exercise {
  public exerciseId: number;
  public exerciseName: string;  
  public exerciseImageFirst: string;
  public exerciseImageSecond: string;
  muscleGroups: MuscleGroup[];
}
