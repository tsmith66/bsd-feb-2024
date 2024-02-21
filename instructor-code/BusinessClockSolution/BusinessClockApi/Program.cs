using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Above this line is "internal" configuration stuff.
var app = builder.Build();
// after this line is configuration for the "middleware" 
//   - how actual HTTP requests are handled and responses are sent.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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