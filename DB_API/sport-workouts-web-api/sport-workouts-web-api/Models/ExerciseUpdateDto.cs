using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Models
{
    public class ExerciseUpdateDto
    {
        [Required(ErrorMessage = "Nenurodytas Id")]
        public int ExerciseId { get; set; }
        [Required(ErrorMessage = "Nenurodytas pavadinimas")]
        public string ExerciseName { get; set; }
        public string ExerciseImageFirst { get; set; }
        public string ExerciseImageSecond { get; set; }
        public virtual ICollection<MuscleGroupsGetDto> MuscleGroups { get; set; }
    }
}