﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_App.Startup))]
namespace Vidly_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
