using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EmployeeApi.API;

public class ExceptionMiddleware
{
    private RequestDelegate Next { get; }

    public ExceptionMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await Next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDeatils = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = ex.Message,
                Instance = "",
                Title = "Unexpected Error - Something went wrong.",
                Type = "Error"
            };

            var problemDetailsJson = JsonSerializer.Serialize(problemDeatils);
            await context.Response.WriteAsync(problemDetailsJson);
        }
    }
}
