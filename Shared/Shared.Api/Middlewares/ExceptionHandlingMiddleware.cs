using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Shared.Application.Exceptions;
using Shared.Application.Responses;

namespace Shared.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
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

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        switch (ex)
        {
            case ValidationException validationException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                
                return context.Response.WriteAsync(
                    JsonSerializer.Serialize(
                        new BaseResponse("Validation Error", false)
                        {
                            ValidationErrors = validationException.ValidationErrors
                        }
                    )
                );
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsync(
                    JsonSerializer.Serialize(
                        new BaseResponse($"{ex.Message}", false)
                    )
                );
        }
    }
}
