using System.Net;
using System.Text.Json;
using Exercises.API.Errors;
using Exercises.Application.Exceptions;

namespace Exercises.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly IHostEnvironment _environment;
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            IHostEnvironment environment, 
            RequestDelegate requestDelegate, 
            ILogger<ExceptionMiddleware> logger)
        {
            _environment = environment;
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (ValidationErrorException ex)
            {
                await HandleValidationErrorException(ex, context);
            }
            catch (NotFoundException ex)
            {
                await HandleNotFoundException(ex, context);
            }
            catch (Exception ex)
            {
                await HandleDefaultException(ex, context);
            }
        }

        private async Task HandleValidationErrorException(ValidationErrorException ex, HttpContext context)
        {
            LogError(ex);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new ApiException((int)HttpStatusCode.BadRequest, ex.Errors, ex.Message);
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }

        private async Task HandleNotFoundException(NotFoundException ex, HttpContext context)
        {
            LogError(ex);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var response = new ApiException((int)HttpStatusCode.NotFound, ex.Message);
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }

        private async Task HandleDefaultException(Exception ex, HttpContext context)
        {
            LogError(ex);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _environment.IsDevelopment()
                ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                : new ApiException(context.Response.StatusCode, "Internal Server Error");

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }

        private void LogError(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }
}
