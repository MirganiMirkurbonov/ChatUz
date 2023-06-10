using System.Net;
using Infrastructure.RequestHandlers.Enums;
using Infrastructure.RequestHandlers.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.RequestHandlers.Middlewares;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;
    //private readonly ILoggerManager _logger;
    public ExceptionHandler(RequestDelegate next)
    {
        //_logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            //_logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync ( JsonConvert.SerializeObject(new ErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.InternalServerError)));
    }
}