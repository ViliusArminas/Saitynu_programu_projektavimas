using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Classes
{
    public class WorkoutDay
    {
        public WorkoutDay()
        {

        }

        public int WorkoutDayId { get; set; }
        public int WorkoutDayMonthWeek { get; set; }
        public int WorkoutDayWeekDay { get; set; }

        public virtual Workout Workout { get; set; }
    }
}