namespace Shared.Application.Responses;

public record BaseResponse
{
    public BaseResponse()
    {
        Success = true;
    }
    
    public BaseResponse(string message)
    {
        Success = true;
        Message = message;
    }

    public BaseResponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; init; }

    public string Message { get; init; } = string.Empty;

    public List<string> ValidationErrors { get; init; } = new List<string>();
}

public record BaseResponse<T> : BaseResponse
{
    public T? Response { get; init; }
}
