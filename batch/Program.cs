using Microsoft.AspNetCore.Mvc;
using Dapr;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Dapr configurations
app.UseCloudEvents();

app.MapSubscribeHandler();

app.MapPost("jobexecute", [Topic("batch-param", "params")] ([FromBody] BatchParams param) => {
    Console.WriteLine($"jobexecute params:{param.JobName}");
    return Results.Ok();
});

Console.WriteLine("run app!");
app.Run();

class BatchParams
{
    public string JobName { get; init; }
}