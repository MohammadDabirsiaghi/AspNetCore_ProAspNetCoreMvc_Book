using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ErrorMiddleware
    {
        private RequestDelegate nextDelegate;
        public ErrorMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);


            if (httpContext.Response.StatusCode == 403)
                await httpContext.Response.WriteAsync("Error 403",Encoding.UTF8);

            if (httpContext.Response.StatusCode == 404)
                await httpContext.Response.WriteAsync("Error 404", Encoding.UTF8);

        }
    }
}
