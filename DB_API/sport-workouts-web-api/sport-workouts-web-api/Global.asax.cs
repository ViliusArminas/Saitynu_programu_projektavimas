using AutoMapper;
using Newtonsoft.Json.Serialization;
using sport_workouts_web_api.Classes;
using sport_workouts_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace sport_workouts_web_api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Workout, WorkoutGetDto>();
                cfg.CreateMap<Exercise, ExercisesGetDto>();
                cfg.CreateMap<WorkoutDay, WorkoutDaysGetDto>();
                cfg.CreateMap<WorkoutDaysGetDto, WorkoutDay>();

                cfg.CreateMap<MuscleGroup, MuscleGroupsGetDto>();
                cfg.CreateMap<MuscleGroupsPostDto, MuscleGroup>();
                cfg.CreateMap<MuscleGroupsUpdateDto, MuscleGroup>();

                cfg.CreateMap<ExercisePostDto, Exercise>()
                 .ForMember(d => d.MuscleGroups, m => m.Ignore());

                cfg.CreateMap<WorkoutPostDto, Workout>()
                 .ForMember(d => d.MuscleGroups, m => m.Ignore())
                 .ForMember(d => d.WorkoutDays, m => m.Ignore())
                 .ForMember(d => d.Exercises, m => m.Ignore());

                cfg.CreateMap<WorkoutUpdateDto, Workout>()
                 .ForMember(d => d.MuscleGroups, m => m.Ignore())
                 .ForMember(d => d.WorkoutDays, m => m.Ignore())
                 .ForMember(d => d.Exercises, m => m.Ignore());

                cfg.CreateMap<ExerciseUpdateDto, Exercise>()
                .ForMember(d => d.MuscleGroups, m => m.Ignore());
            });
        }

       

    }
}
