using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Models
{
    public class MuscleGroupsPostDto
    {
        [Required(ErrorMessage = "Nenurodytas pratimo pavadinimas")]
        public string MuscleGroupName { get; set; }
    }
}