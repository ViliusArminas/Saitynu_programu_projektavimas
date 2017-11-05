using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Classes
{
    public class MuscleGroup
    {
        public MuscleGroup()
        {
            this.Exercises = new HashSet<Exercise>();
            this.Workouts = new HashSet<Workout>();
        }
        public int MuscleGroupId { get; set; }
        public string MuscleGroupName { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}