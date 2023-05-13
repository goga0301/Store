using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Store.Shared.Helpers
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<ErrorMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "მოხდა შეცდომა");

                try
                {
                    var json = JsonSerializer.Serialize(ApiResponse.Error(ex.Message));

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    await context.Response.WriteAsync(json).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "error occured after response has already started requestPath={requestPath}, parentException={parentEception}", context.Request.Path.Value, ex);
                }
            }

        }
    }

    public static class ErrorMidlewareExtensions
    {
        public static void UseError(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}
