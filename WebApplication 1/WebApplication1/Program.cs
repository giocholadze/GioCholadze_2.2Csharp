using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var customers = new List<Customer>()
{
    new Customer(1, "Gio", true),
    new Customer(2, "Alice", false)
};

app.MapGet("/customers", () =>
{
    return Results.Ok(customers);  
});

app.MapGet("/customers/{id}", (int id) =>
{
    var customer = customers.SingleOrDefault(c => c.id == id);
    return Results.Ok(customer);  
});

app.Run();

public record Customer(int id, string name, bool isSatisfied);
