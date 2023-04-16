using Beeshtiha.Models;
using Beeshtiha.Service.Exeptions;
using System;

namespace Beeshtiha.Middlewaers;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    { this.next = next; }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch(BeeshtihaExeption ex)
        {
            context.Response.StatusCode = ex.code;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = ex.code,
                Error = ex.Message
            });
        }
        catch(Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = 500,
                Error = ex.Message
            });
        }
    }
}
