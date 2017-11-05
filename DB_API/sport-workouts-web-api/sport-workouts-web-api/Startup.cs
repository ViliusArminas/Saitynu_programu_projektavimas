using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(sport_workouts_web_api.Startup))]

namespace sport_workouts_web_api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }
    }
}
