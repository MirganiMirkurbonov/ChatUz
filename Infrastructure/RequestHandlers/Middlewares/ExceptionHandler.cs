using System.Net;
using Infrastructure.RequestHandlers.Enums;
using Infrastructure.RequestHandlers.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

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
    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // TODO : change generic type if defaultResponse and simplify
        await context.Response.WriteAsync ( JsonConvert.SerializeObject(new DefaultResponse<string>( new ErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.InternalServerError))
        {
            Success = false,
            Result = null
        }));
    }
   
}