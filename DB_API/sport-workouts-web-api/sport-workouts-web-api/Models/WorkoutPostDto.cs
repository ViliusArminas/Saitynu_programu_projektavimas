using sport_workouts_web_api.Classes;
using sport_workouts_web_api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Models
{
    public class WorkoutPostDto
    {
        [Required(ErrorMessage = "Nenurodytas rutinos pavadinimas")]
        public string WorkoutName { get; set; }

        public virtual ICollection<ExercisesGetDto> Exercises { get; set; }
        public virtual ICollection<MuscleGroupsGetDto> MuscleGroups { get; set; }
        public virtual ICollection<WorkoutDaysPostDto> WorkoutDays { get; set; }
    }
}