using WholesaleStore.Common.Responses;

namespace WholesaleStore.Common.Exceptions;

/// <summary>
/// Exception for catch structured errors
/// </summary>
public class ErrorResponseException : Exception
{
    public ErrorResponse ErrorResponse { get; } = new();

    public ErrorResponseException()
    {
    }

    public ErrorResponseException(string message) : base(message)
    {
    }

    public ErrorResponseException(Exception inner) : base(inner.Message, inner)
    {
    }

    public ErrorResponseException(string message, Exception inner) : base(message, inner)
    {
    }

    public ErrorResponseException(ErrorResponse errorResponse) : base()
    {
        ErrorResponse = errorResponse;
    }

    public ErrorResponseException(ErrorResponse errorResponse, Exception inner) : base(null, inner)
    {
        ErrorResponse = errorResponse;
    }
}
