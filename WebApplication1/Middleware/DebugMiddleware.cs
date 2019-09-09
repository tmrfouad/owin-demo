using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task
    >;

namespace WebApplication1.Middleware
{
    public class DebugMiddleware
    {
        private AppFunc _next;
        DebugMiddlewareOptions _options;

        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;

            if (_options.OnIncommingRequest == null)
                _options.OnIncommingRequest = (ctx) => {
                    Debug.WriteLine($"Incomming request: {ctx.Request.Path}");
                };

            if (_options.OnOutgoingRequest == null)
                _options.OnOutgoingRequest = (ctx) => {
                    Debug.WriteLine($"Outgoing request: {ctx.Request.Path}");
                };
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);

            _options.OnIncommingRequest(ctx);
            await _next(environment);
            _options.OnOutgoingRequest(ctx);
        }
    }
}