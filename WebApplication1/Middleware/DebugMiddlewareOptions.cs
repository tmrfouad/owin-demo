﻿using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Middleware
{
    public class DebugMiddlewareOptions
    {
        public Action<IOwinContext> OnIncommingRequest { get; set; }
        public Action<IOwinContext> OnOutgoingRequest { get; set; }
    }
}