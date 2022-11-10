using Microsoft.AspNetCore.Mvc;
using Dapr;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Dapr configurations
app.UseCloudEvents();

app.MapSubscribeHandler();

app.MapPost("jobexecute-a", [Topic("batch-param", "job-a-params")] ([FromBody] JobAParams param) => {
    Console.WriteLine($"jobexecute A. params:{param.Order}");
    return Results.Ok();
});

app.MapPost("jobexecute-b", [Topic("batch-param", "job-b-params")] ([FromBody] EmptyJobParams param) => {
    Console.WriteLine($"jobexecute B. param is empty");
    return Results.Ok();
});

app.MapPost("jobexecute-c", [Topic("batch-param", "job-c-params")] ([FromBody] EmptyJobParams param) => {
    Console.WriteLine($"jobexecute C. job is fail");
    return Results.Problem("job is fail");
});

Console.WriteLine("run app!");
app.Run();

class JobAParams
{
    public int Order { get; set; }
}

class EmptyJobParams
{
}