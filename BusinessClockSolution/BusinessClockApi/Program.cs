using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Above this line is "internal" configuration stuff.
var app = builder.Build();

//After this line is configuration for the "middleware".
//- how actual HTTP requests are handled and responses are sent.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// GET /
app.MapGet("/support-info", ([FromServices] IProvideTheBusinessClock clock) =>
{
    if (clock.IsOpen())
    {
        return new SupportInfoResponse("Graham", "555-1212");
    }
    else
    {
        return new SupportInfoResponse("TechSupportPros", "800-STUF-BROKE");
    }
});

app.Run();

public record SupportInfoResponse(string Name, string Phone);

public interface IProvideTheBusinessClock
{
    bool IsOpen();
}

public partial class Program { }