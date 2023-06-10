using Infrastructure.RequestHandlers.ContextHelper;
using Infrastructure.RequestHandlers.Enums;
using System.Net;

namespace Infrastructure.RequestHandlers.Models;

public class ErrorResponse
{
    public string Message { get; set; }
    public int Code { get; set; }

    public ErrorResponse(HttpStatusCode statusCode, ErrorCodes code)
    {
        if (HttpContextHelper.Current?.Response != null)
            HttpContextHelper.Current.Response.StatusCode = (int)statusCode;

        Code = (int)code;
        Message = code.ToString();
    }


    public ErrorResponse(HttpStatusCode statusCode, ErrorCodes code, string message)
    {
        if (HttpContextHelper.Current?.Response != null)
            HttpContextHelper.Current.Response.StatusCode = (int)statusCode;

        Code = (int)code;
        Message = code.ToString() + message;
    }

    public ErrorResponse(ErrorCodes code)
    {
        if (HttpContextHelper.Current?.Response != null)
            HttpContextHelper.Current.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        Code = (int)code;
        Message = code.ToString();
    }
}