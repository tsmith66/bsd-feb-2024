
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

app.MapGet("/support-info", () =>
{
    return new SupportInfoResponse("Graham", "555-1212");
});

app.Run();


public record SupportInfoResponse(string Name, string Phone);