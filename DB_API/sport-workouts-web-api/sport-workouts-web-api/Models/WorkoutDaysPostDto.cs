using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Models
{
    public class WorkoutDaysPostDto
    {
        [Required(ErrorMessage = "Nenurodyta mėnesio savaitė")]
        public int WorkoutDayMonthWeek { get; set; }
        [Required(ErrorMessage = "Nenurodyta savaitės diena")]
        public int WorkoutDayWeekDay { get; set; }
    }
}