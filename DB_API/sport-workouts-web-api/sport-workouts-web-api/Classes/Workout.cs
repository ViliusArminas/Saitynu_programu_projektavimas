using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Classes
{
    public class Workout
    {
        public Workout()
        {
            this.Exercises = new HashSet<Exercise>();
            this.MuscleGroups = new HashSet<MuscleGroup>();
            this.WorkoutDays = new HashSet<WorkoutDay>();

        }
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<MuscleGroup>MuscleGroups { get; set; }
        public virtual ICollection<WorkoutDay> WorkoutDays { get; set; }
    }
   
}