using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using sport_workouts_web_api.Classes;
using sport_workouts_web_api.Models;
using System.Web.Http.Cors;

namespace sport_workouts_web_api.Controllers
{
    [Authorize]
    [EnableCorsAttribute("http://localhost:4200","*","*")]
    public class WorkoutsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Workouts
        public List<WorkoutGetDto> GetWorkouts()
        {
            var list= db.Workouts.ToList();

            var resList = new List<WorkoutGetDto>();

            /* foreach (var i in list)
             {
                 resList.Add(new WorkoutGetDto()
                 {
                 WorkoutId = i.WorkoutId,
                 WorkoutName = i.WorkoutName
                 });
             }*/

            var result =  AutoMapper.Mapper.Map<List<WorkoutGetDto>>(list);
            return result;
        }

        // GET: api/Workouts/5
        //[ResponseType(typeof(Workout))]
        //[EnableCorsAttribute("http://localhost:4200", "*", "*")]
        public WorkoutGetDto GetWorkout(int id)
        {
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return null;
            }

            WorkoutGetDto result = AutoMapper.Mapper.Map<WorkoutGetDto>(workout);
            return result;
        }

        // PUT: api/Workouts/5
        [ResponseType(typeof(void))]
        [Route("api/workouts/update/{id}")]
        public IHttpActionResult PutWorkout(int id, WorkoutUpdateDto workout)
        {
           /* if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            if (id != workout.WorkoutId)
            {
                return BadRequest();
            }
            var work = db.Workouts.Find(id);
            AutoMapper.Mapper.Map(workout, work);

            // Making list of musclegroups ids got from dto
            var workoutMuscleGroupsIdList = new List<int>();
            foreach (var i in workout.MuscleGroups)
            {
                workoutMuscleGroupsIdList.Add(i.MuscleGroupId);
            }

            // Checking if musclegroup existed in current workout, if not, remove it
            foreach (var i in work.MuscleGroups.ToList())
            {
                if (!workoutMuscleGroupsIdList.Contains(i.MuscleGroupId))
                    work.MuscleGroups.Remove(i);
            }

            // Cheking if muscle group exists in database and adds it to workout if it does
            foreach (var i in workout.MuscleGroups)
            {
                if (!work.MuscleGroups.Any(r => r.MuscleGroupId == i.MuscleGroupId))
                {
                    var addMuscleGroup = db.MuscleGroups.Find(i.MuscleGroupId);
                    work.MuscleGroups.Add(addMuscleGroup);
                }
            }

            // Making list of exercises ids got from dto
            var workoutExerciseIdList = new List<int>();
            foreach (var i in workout.Exercises)
            {
                workoutExerciseIdList.Add(i.ExerciseId);
            }

            // Checking if exercise existed in current workout, if not, remove it
            foreach (var i in work.Exercises.ToList())
            {
                if (!workoutExerciseIdList.Contains(i.ExerciseId))
                    work.Exercises.Remove(i);
            }

            // Cheking if muscle group exists in database and adds it to workout if it does
            foreach (var i in workout.Exercises)
            {
                if (!work.Exercises.Any(r => r.ExerciseId == i.ExerciseId))
                {
                    var addExercise = db.Exercises.Find(i.ExerciseId);
                    work.Exercises.Add(addExercise);
                }
            }


            // Making list of workoutDays ids got from dto
            var workoutWorkoutDaysIdList = new List<int>();
            foreach (var i in workout.WorkoutDays)
            {
                workoutWorkoutDaysIdList.Add(i.WorkoutDayId);
            }

            // Checking if workoutDay existed in current workout, if not, remove it
            foreach (var i in work.WorkoutDays.ToList())
            {
                if (!workoutWorkoutDaysIdList.Contains(i.WorkoutDayId))
                    work.WorkoutDays.Remove(i);
            }

            // Cheking if muscle group exists in database and adds it to workout if it does
            foreach (var i in workout.WorkoutDays)
            {
                // if workday is new, than create new and add to workout
                if (i.WorkoutDayId == 0)
                {
                    var workoutWorkoutDaysNew = new List<WorkoutDay>();
                    foreach (var j in workout.WorkoutDays)
                    {
                        var workoutDays = new WorkoutDay();
                        workoutDays.WorkoutDayMonthWeek = j.WorkoutDayMonthWeek;
                        workoutDays.WorkoutDayWeekDay = j.WorkoutDayWeekDay;
                        workoutWorkoutDaysNew.Add(workoutDays);
                    }
                    work.WorkoutDays = workoutWorkoutDaysNew;
                }

                // if workday already existed, find it and change its values
                else
                {
                    var workday = db.WorkoutDays.Find(i.WorkoutDayId);
                    workday.WorkoutDayMonthWeek = i.WorkoutDayMonthWeek;
                    workday.WorkoutDayWeekDay = i.WorkoutDayWeekDay;
                   
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var updatedWorkout = db.Workouts.Find(id);
            WorkoutGetDto result = AutoMapper.Mapper.Map<WorkoutGetDto>(updatedWorkout);
            return Ok(result);
        }

        // POST: api/Workouts
        //[ResponseType(typeof(Workout))]
        [EnableCorsAttribute("http://localhost:4200", "*", "*")]
        public IHttpActionResult PostWorkout(WorkoutPostDto workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            var insertItem = AutoMapper.Mapper.Map<Workout>(workout);

            // muscleGroups entities assigned to workout by ids from dto information
            var muscleGroups = db.MuscleGroups.ToList();
            var workoutMuscleGroups = new List<MuscleGroup>();
            foreach (var i in workout.MuscleGroups)
            {
                workoutMuscleGroups.Add(muscleGroups.Single(a => a.MuscleGroupId == i.MuscleGroupId));
            }
            insertItem.MuscleGroups = workoutMuscleGroups;
            // ---------------------------

            // exercises entities assigned to workout by ids from dto information
            var exercises = db.Exercises.ToList();
            var workoutExercises = new List<Exercise>();
            foreach (var i in workout.Exercises)
            {
                workoutExercises.Add(exercises.Single(a => a.ExerciseId == i.ExerciseId));
            }
            insertItem.Exercises = workoutExercises;
            // ---------------------------

            // workoutDays entities created to workout from dto information
            var workoutWorkoutDays = new List<WorkoutDay>();
            foreach (var i in workout.WorkoutDays)
            {
                var workoutDays = new WorkoutDay();
                workoutDays.WorkoutDayMonthWeek = i.WorkoutDayMonthWeek;
                workoutDays.WorkoutDayWeekDay = i.WorkoutDayWeekDay;
                workoutWorkoutDays.Add(workoutDays);
            }
            insertItem.WorkoutDays = workoutWorkoutDays;
            // ---------------------------

            // Inserting new workout with all information
            db.Workouts.Add(insertItem);
            db.SaveChanges();

            var workoutDto = AutoMapper.Mapper.Map<WorkoutGetDto>(insertItem);

            return CreatedAtRoute("DefaultApi", new { id = workoutDto.WorkoutId }, workoutDto);
        }

        // DELETE: api/Workouts/5
        [ResponseType(typeof(Workout))]
        public IHttpActionResult DeleteWorkout(int id)
        {
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return NotFound();
            }

            //db.Workouts.Remove(workout);
            //db.SaveChanges();
            string result = "attempted to delete item with ID = " + id;
            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkoutExists(int id)
        {
            return db.Workouts.Count(e => e.WorkoutId == id) > 0;
        }
    }
}