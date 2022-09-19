using System.Net;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerFactory _loggerFactory;
    public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        var _logger = _loggerFactory.CreateLogger<ExceptionMiddleware>();

        try
        {
             _logger.LogInformation("Performing Middleware operation");
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex, _logger);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ExceptionMiddleware> _logger)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        }.ToString());

        _logger.LogError(exception.Message);
    }
}