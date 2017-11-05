using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Classes
{
    public class Exercise
    {
        public Exercise()
        {
            this.Workouts = new HashSet<Workout>();
            this.MuscleGroups = new HashSet<MuscleGroup>();

        }
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }

       [DefaultValue("assets/images/noimg.png")]
        public string ExerciseImageFirst { get; set; }
        [DefaultValue("assets/images/noimg.png")]
        public string ExerciseImageSecond { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<MuscleGroup> MuscleGroups { get; set; }
    }



}