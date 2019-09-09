﻿using Nancy;
using Nancy.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modules
{
    public class NancyDemoModule : NancyModule
    {
        public NancyDemoModule()
        {
            Get("/nancy", x => {
                var env = Context.GetOwinEnvironment();
                return $"Hello from Nancy! You requested: {env["owin.RequestPathBase"]} {env["owin.RequestPath"]}";
            });
        }
    }
}