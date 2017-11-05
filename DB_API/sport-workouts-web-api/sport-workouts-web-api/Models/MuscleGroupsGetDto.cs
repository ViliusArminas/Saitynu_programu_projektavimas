using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sport_workouts_web_api.Models
{
    public class MuscleGroupsGetDto
    {
        public int MuscleGroupId { get; set; }
        public string MuscleGroupName { get; set; }
    }
}