using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegare;
        public ShortCircuitMiddleware(RequestDelegate next)
        {
            nextDelegare = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers["User-Agent"].Any(h => h.ToLower().Contains("edge")))
            {
                httpContext.Response.StatusCode = 403;
            }
            else
              await  nextDelegare.Invoke(httpContext);

        }
    }
}
