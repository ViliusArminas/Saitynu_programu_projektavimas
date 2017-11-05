using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Models
{
    public class WorkoutDaysGetDto
    {
        public int WorkoutDayId { get; set; }
        public int WorkoutDayMonthWeek { get; set; }
        public int WorkoutDayWeekDay { get; set; }
    }
}