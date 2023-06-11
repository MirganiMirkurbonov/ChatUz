using Infrastructure.RequestHandlers.ContextHelper;

namespace Infrastructure.RequestHandlers.Models;

public class DefaultResponse<T>
{
    public bool Success { get; set; } = true;

    public T? Result { get; set; }

    public ErrorResponse Error { get; set; }


    public DefaultResponse(T result)
    {
        HttpContextHelper.Current.Response.StatusCode = 200;
        Success = true;
        Result = result;
    }


    public DefaultResponse(ErrorResponse error)
    {
        Error = error;
        Success = false;
    }


    public static implicit operator DefaultResponse<T>(T result) => new(result);

    public static implicit operator DefaultResponse<T>(ErrorResponse error) => new(error);


}