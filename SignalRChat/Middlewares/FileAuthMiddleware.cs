using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Middlewares
{
    public class FileAuthMiddleware
    {
        private readonly RequestDelegate next;

        public FileAuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var contextAccess = httpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();
            var path = httpContext.Request.Path;
            if (path == "/chat.html")
            {
                contextAccess.HttpContext.Session.Clear();
                var sessionValue = contextAccess.HttpContext.Session.GetString("UserName");
                if (!string.IsNullOrWhiteSpace(sessionValue))
                {
                    await next(httpContext);

                }
                else
                {
                    httpContext.Response.StatusCode = 403;
                }
            }
            else
            {
                await next(httpContext);
            }
        }
    }
}
