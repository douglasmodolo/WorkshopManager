using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorkshopManager.Domain.Exceptions;

namespace WorkshopManager.API.Middleware
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            var (statusCode, title) = exception switch
            {
                NotFoundException => (StatusCodes.Status404NotFound, "Recurso não encontrado"),
                BusinessException => (StatusCodes.Status400BadRequest, "Regra de negócio violada"),
                ValidationException => (StatusCodes.Status400BadRequest, "Erro de Validação"),
                _ => (StatusCodes.Status500InternalServerError, "Erro interno do servidor")
            };

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = exception is ValidationException valEx
                    ? string.Join(", ", valEx.Errors.Select(e => e.ErrorMessage))
                    : exception.Message,
                Instance = httpContext.Request.Path
            };

            if (statusCode == StatusCodes.Status500InternalServerError)
            {
                problemDetails.Detail = "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.";
            }

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
