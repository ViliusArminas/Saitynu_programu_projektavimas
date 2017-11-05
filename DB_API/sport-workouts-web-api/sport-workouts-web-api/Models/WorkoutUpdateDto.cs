using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sport_workouts_web_api.Models
{
    public class WorkoutUpdateDto
    {
        [Required(ErrorMessage = "Nenurodytas Id")]
        public int WorkoutId { get; set; }
        [Required(ErrorMessage = "Nenurodytas rutinos pavadinimas")]
        public string WorkoutName { get; set; }

        public virtual ICollection<ExercisesGetDto> Exercises { get; set; }
        public virtual ICollection<MuscleGroupsGetDto> MuscleGroups { get; set; }
        public virtual ICollection<WorkoutDaysGetDto> WorkoutDays { get; set; }
    }
}