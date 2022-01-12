using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MiddleWare
{
    public class TimeMiddleware : IMiddleware
    {
        private readonly Stopwatch _stopwatch;
        private readonly ILogger<TimeMiddleware> _logger;

        public TimeMiddleware(ILogger<TimeMiddleware> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

            var seconds = _stopwatch.ElapsedMilliseconds;
            if(seconds / 1000 > 4)
            {
                var messsage = $"Request : {context.Request.Method} at {context.Request.Path} took {seconds} ms";
                _logger.LogInformation (messsage);

            }
        }
    }
}
