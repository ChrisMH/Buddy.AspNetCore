using System;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Buddy.AspNetCore.Web
{
    public static class RequestLogger
    {
        public const string LogFormat = "{0} | {1} {2}";

        public static IApplicationBuilder UseSimpleLogger(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger(nameof(RequestLogger));

            app.Use(async (context, next) =>
            {
                await next();
                
                var status = context.Response.StatusCode;
                var method = context.Request.Method;
                var path = context.Request.Path + WebUtility.UrlDecode(context.Request.QueryString.Value);

                if (status < 400)
                    logger.LogInformation(LogFormat, status, method, path);
                else if (status < 500)
                    logger.LogWarning(LogFormat, status, method, path);
                else
                    logger.LogError(LogFormat, status, method, path);
            });

            return app;
        }
    }
}