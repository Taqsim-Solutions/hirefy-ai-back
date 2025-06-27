using System.Net;
using Common;
using System.Text.Json;
using FluentValidation;
using HirefyAI.Application.Helpers;

namespace Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex, "Resource not found");
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.Unauthorized, ex, "Unauthorized access");
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex, "Request is not valid");
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
                var errorMessage = string.Join(", ", errors);
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex, errorMessage);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, ex, "Request is not valid");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, Exception ex, string errorMessage)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var result = Result.Fail(errorMessage);
            var jsonResult = JsonSerializer.Serialize(result);
            await context.Response.WriteAsync(jsonResult);
            await TelegramBotHelper.SendExceptionAsync(ex, context);
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}