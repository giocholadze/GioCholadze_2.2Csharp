using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class Middleware
{
    private readonly RequestDelegate _next;

    public Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Middleware Invoked: Before Request");

        await _next(context);

        Console.WriteLine("Middleware Invoked: After Request");
    }
}
