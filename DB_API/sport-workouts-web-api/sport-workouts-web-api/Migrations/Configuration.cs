namespace sport_workouts_web_api.Migrations
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<sport_workouts_web_api.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(sport_workouts_web_api.Models.ApplicationDbContext context)
        {
          
            
            if (!context.MuscleGroups.Any())
            {
                string image_url = "assets/images/";
                // Main muscle groups
                MuscleGroup muscleGroup1 = new MuscleGroup() { MuscleGroupName = "Nugara" };
                MuscleGroup muscleGroup2 = new MuscleGroup() { MuscleGroupName = "Pilvo presas" };
                MuscleGroup muscleGroup3 = new MuscleGroup() { MuscleGroupName = "Rankos" };
                MuscleGroup muscleGroup4 = new MuscleGroup() { MuscleGroupName = "Kojos" };
                MuscleGroup muscleGroup5 = new MuscleGroup() { MuscleGroupName = "Krūtinė" };

                // Exercises for chest
                Exercise Exercise1 = new Exercise() { ExerciseName = "Štangos spaudimas", ExerciseImageFirst = image_url + "stangos_spaudimas.gif", ExerciseImageSecond = image_url + "stangos_spaudimas.gif" };
                Exercise Exercise2 = new Exercise() { ExerciseName = "Krūtinės plėšimas", ExerciseImageFirst = image_url + "plesimas_tiesiai.gif", ExerciseImageSecond = image_url + "plesimas_tiesiai.gif" };
                Exercise Exercise3 = new Exercise() { ExerciseName = "Puloveris", ExerciseImageFirst = image_url + "DumbbellPullover.gif", ExerciseImageSecond = image_url + "DumbbellPullover.gif" };

                // Exercises for back
                Exercise Exercise4 = new Exercise() { ExerciseName = "Prisitraukimai", ExerciseImageFirst = image_url + "prisitrukimai_prie_kaklo.gif", ExerciseImageSecond = image_url + "prisitrukimai_prie_kaklo.gif" };
                Exercise Exercise5 = new Exercise() { ExerciseName = "Lyno trauka prie pilvo", ExerciseImageFirst = image_url + "lyno_trauka_prie_pilvo.gif", ExerciseImageSecond = image_url + "lyno_trauka_prie_pilvo.gif" };
                Exercise Exercise6 = new Exercise() { ExerciseName = "Nugaros tiesimas", ExerciseImageFirst = image_url + "atilenkimai_nugaros_apaciai.gif", ExerciseImageSecond = image_url + "atilenkimai_nugaros_apaciai.gif" };

                // Exercises for legs
                Exercise Exercise7 = new Exercise() { ExerciseName = "Pritūpimai", ExerciseImageFirst = image_url + "pritupimai.gif", ExerciseImageSecond = image_url + "pritupimai.gif" };
                Exercise Exercise8 = new Exercise() { ExerciseName = "Įtūpstai su hanteliais", ExerciseImageFirst = image_url + "itupstai_su_hanteliais.gif", ExerciseImageSecond = image_url + "itupstai_su_hanteliais.gif" };

                // Exercises for hands
                Exercise Exercise9 = new Exercise() { ExerciseName = "Stovint su hanteliais", ExerciseImageFirst = image_url + "stovint_su_hanteliais.gif", ExerciseImageSecond = image_url + "stovint_su_hanteliais.gif" };
                Exercise Exercise10 = new Exercise() { ExerciseName = "Štangos spaudimas siaurai", ExerciseImageFirst = image_url + "stangos_spaudimas_siaurai.gif", ExerciseImageSecond = image_url + "stangos_spaudimas_siaurai.gif" };


                // Exercises for abs
                Exercise Exercise11 = new Exercise() { ExerciseName = "Atsilenkimai", ExerciseImageFirst = image_url + "atsilenkimai.gif", ExerciseImageSecond = image_url + "atsilenkimai.gif" };
                Exercise Exercise12 = new Exercise() { ExerciseName = "Atsilenkimai šonu", ExerciseImageFirst = image_url + "atsilenkimia_sonu.gif", ExerciseImageSecond = image_url + "atsilenkimia_sonu.gif" };

                WorkoutDay WorkoutDay1 = new WorkoutDay() { WorkoutDayMonthWeek = 1, WorkoutDayWeekDay = 1 };
                WorkoutDay WorkoutDay2 = new WorkoutDay() { WorkoutDayMonthWeek = 2, WorkoutDayWeekDay = 3 };
                WorkoutDay WorkoutDay3 = new WorkoutDay() { WorkoutDayMonthWeek = 3, WorkoutDayWeekDay = 2 };
                WorkoutDay WorkoutDay4 = new WorkoutDay() { WorkoutDayMonthWeek = 4, WorkoutDayWeekDay = 6 };
               

                // Workouts
                Workout Workout1 = new Workout() { WorkoutName = "Kojų ir pilvo preso treniruotė" };
                Workout Workout2 = new Workout() { WorkoutName = "Krūtinės ir rankų treniruotė" };
                Workout Workout3 = new Workout() { WorkoutName = "Nugaros treniruotė" };

                // Legs and abs workout muscle groups
                Workout1.MuscleGroups.Add(muscleGroup2);
                Workout1.MuscleGroups.Add(muscleGroup4);
                muscleGroup2.Workouts.Add(Workout1);
                muscleGroup4.Workouts.Add(Workout1);

                // Legs and abs workout exercises
                Workout1.Exercises.Add(Exercise7);
                Workout1.Exercises.Add(Exercise8);
                Workout1.Exercises.Add(Exercise11);
                Workout1.Exercises.Add(Exercise12);
                Exercise7.Workouts.Add(Workout1);
                Exercise8.Workouts.Add(Workout1);
                Exercise11.Workouts.Add(Workout1);
                Exercise12.Workouts.Add(Workout1);

                // Chest and hands workout muscle groups
                Workout2.MuscleGroups.Add(muscleGroup3);
                Workout2.MuscleGroups.Add(muscleGroup5);
                muscleGroup3.Workouts.Add(Workout2);
                muscleGroup5.Workouts.Add(Workout2);

                // Chest and hands workout exercises
                Workout2.Exercises.Add(Exercise1);
                Workout2.Exercises.Add(Exercise2);
                Workout2.Exercises.Add(Exercise3);
                Workout2.Exercises.Add(Exercise9);
                Workout2.Exercises.Add(Exercise10);
                Exercise1.Workouts.Add(Workout2);
                Exercise2.Workouts.Add(Workout2);
                Exercise3.Workouts.Add(Workout2);
                Exercise9.Workouts.Add(Workout2);
                Exercise10.Workouts.Add(Workout2);

                // Back workout muscle groups
                Workout3.MuscleGroups.Add(muscleGroup1);
                muscleGroup1.Workouts.Add(Workout3);

                // Legs and abs workout exercises
                Workout3.Exercises.Add(Exercise4);
                Workout3.Exercises.Add(Exercise5);
                Workout3.Exercises.Add(Exercise6);
                Exercise4.Workouts.Add(Workout3);
                Exercise5.Workouts.Add(Workout3);
                Exercise6.Workouts.Add(Workout3);

                // Leg exercises with leg muscle group
                Exercise7.MuscleGroups.Add(muscleGroup4);
                Exercise8.MuscleGroups.Add(muscleGroup4);
                muscleGroup4.Exercises.Add(Exercise7);
                muscleGroup4.Exercises.Add(Exercise8);

                // Chest exercises with chest muscle group
                Exercise1.MuscleGroups.Add(muscleGroup5);
                Exercise2.MuscleGroups.Add(muscleGroup5);
                Exercise3.MuscleGroups.Add(muscleGroup5);
                muscleGroup5.Exercises.Add(Exercise1);
                muscleGroup5.Exercises.Add(Exercise2);
                muscleGroup5.Exercises.Add(Exercise3);

                // Back exercises with back muscle group
                Exercise4.MuscleGroups.Add(muscleGroup1);
                Exercise5.MuscleGroups.Add(muscleGroup1);
                Exercise6.MuscleGroups.Add(muscleGroup1);
                muscleGroup1.Exercises.Add(Exercise4);
                muscleGroup1.Exercises.Add(Exercise5);
                muscleGroup1.Exercises.Add(Exercise6);

                // Hands exercises with hands muscle group
                Exercise9.MuscleGroups.Add(muscleGroup3);
                Exercise10.MuscleGroups.Add(muscleGroup3);
                muscleGroup3.Exercises.Add(Exercise9);
                muscleGroup3.Exercises.Add(Exercise10);

                // Abs exercises with abs muscle group
                Exercise11.MuscleGroups.Add(muscleGroup2);
                Exercise12.MuscleGroups.Add(muscleGroup2);
                muscleGroup2.Exercises.Add(Exercise11);
                muscleGroup2.Exercises.Add(Exercise12);

                // Workouts with dates
                Workout1.WorkoutDays.Add(WorkoutDay1);
                Workout1.WorkoutDays.Add(WorkoutDay2);
                Workout2.WorkoutDays.Add(WorkoutDay3);
                Workout3.WorkoutDays.Add(WorkoutDay4);

                // Add all data to database (Workouts now includes all other data)
                context.Workouts.Add(Workout1);
                context.Workouts.Add(Workout2);
                context.Workouts.Add(Workout3);
            }

            


        }
    }
}
