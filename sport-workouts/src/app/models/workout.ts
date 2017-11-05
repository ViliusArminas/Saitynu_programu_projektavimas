import { MuscleGroup } from 'app/models/muscle-group'
import { Exercise } from 'app/models/exercise'
import { WorkoutDay } from 'app/models/workout-day'

export class Workout {
    workoutId: number;
    workoutName: string;
    exercises: Exercise[];
    muscleGroups: MuscleGroup[];
    workoutDays: WorkoutDay[];
}
