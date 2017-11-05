using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Models
{
    public class MuscleGroupsUpdateDto
    {
        [Required(ErrorMessage = "Nenurodytas Id")]
        public int MuscleGroupId { get; set; }
        [Required(ErrorMessage = "Nenurodytas pavadinimas")]
        public string MuscleGroupName { get; set; }
    }
}