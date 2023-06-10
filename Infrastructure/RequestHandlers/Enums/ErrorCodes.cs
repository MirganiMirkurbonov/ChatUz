namespace Infrastructure.RequestHandlers.Enums;

public enum ErrorCodes
{
    InternalServerError,
    InvalidInputParams,
    UsernameAlreadyExists,
    UserBlocked,
    EmailAlreadyExists,
    PhoneAlreadyExists,
    NotAuthorized
}