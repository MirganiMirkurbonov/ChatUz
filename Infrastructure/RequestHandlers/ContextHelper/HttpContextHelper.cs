using Microsoft.AspNetCore.Http;
using System.Net;

namespace Infrastructure.RequestHandlers.ContextHelper;

public class HttpContextHelper
{
    public static IHttpContextAccessor Accessor;

    public HttpContextHelper(IHttpContextAccessor accessor)
    {
        Accessor = accessor;
    }

  
    public static HttpContext Current => Accessor?.HttpContext;

    public static string CurrentMethod => GetCurrentMethod();

    /// <summary />
    /// <returns></returns>
    private static string GetCurrentMethod()
    {
        var request = Accessor?.HttpContext?.Request;
        if (request == null)
            return string.Empty;

        var pathSegments = request.Path.Value?.Split('/');
        return pathSegments?.Length > 1 ? $"{pathSegments[^2].ToLower()}_{pathSegments[^1].ToLower()}" : string.Empty;
    }

    /// <summary />
    public static void SetErrorInBodyCode()
        => SetStatusCode(HttpStatusCode.BadRequest);


    public static void SetStatusCode(HttpStatusCode code)
    {
        if (Current?.Response != null)
            Current.Response.StatusCode = (int)code;
    }
}