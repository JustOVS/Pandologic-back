using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
namespace Pandologic.API.Infrastructure.Middleware
{
  public class ErrorHandlingMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
      _next = next;
      _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      if (exception is AggregateException && exception.InnerException != null)
      {
        exception = exception.InnerException;
      }

      switch (exception)
      {
        default:
          _logger.LogError(exception, "HTTP {RequestMethod} {RequestPath}", context.Request.Method, context.Features.Get<IHttpRequestFeature>()?.RawTarget ?? context.Request.Path.ToString());
          await WriteResponse(HttpStatusCode.InternalServerError, context, "Server error");
          break;
      }
    }

    private static async Task WriteResponse(HttpStatusCode statusCode, HttpContext context, object data = null)
    {
      context.Response.StatusCode = (int)statusCode;
      context.Response.ContentType = "application/json";

      if (data != null)
      {
        await context.Response.WriteAsync(JsonConvert.SerializeObject(data));
      }
    }
  }
}