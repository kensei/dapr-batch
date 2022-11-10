using Microsoft.AspNetCore.Mvc;
using Dapr;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/JobEnqueueA", async (context) => {
    var bodyJson = GetRequestJson(context.Request);
    Console.WriteLine($"JobA enqueue. param:{bodyJson}");
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsJsonAsync(new { status = $"success" });
});

app.MapPost("/JobEnqueueB", async (context) => {
    Console.WriteLine($"JobB enqueue. param is empty");
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsJsonAsync(new { status = $"success" });
});

app.MapPost("/JobEnqueueC", async (context) => {
    Console.WriteLine($"JobC enqueue. result is fail");
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsJsonAsync(new { status = $"fail" });
});

app.MapPost("/JobEnqueueD", async (context) => {
    Console.WriteLine($"JobD enqueue. long job");
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsJsonAsync(new { status = $"success" });
});

app.MapPost("/JobExecute", async () => {
    Console.WriteLine("Processing batch..");

    Console.WriteLine("Finished processing batch");
    return Results.Json("{}");
});

async Task<string> GetRequestJson(HttpRequest request)
{
    var json = string.Empty;
    using (var reader = new StreamReader(request.Body))
    {
        json = await reader.ReadToEndAsync();
    }
    return json;
}

// app.MapPost("jobexecute-a", [Topic("batch-param", "job-a-params")] ([FromBody] JobAParams param) => {
//     Console.WriteLine($"jobexecute A. params:{param.Order}");
//     return Results.Ok();
// });

// app.MapPost("jobexecute-b", [Topic("batch-param", "job-b-params")] ([FromBody] EmptyJobParams param) => {
//     Console.WriteLine($"jobexecute B. param is empty");
//     return Results.Ok();
// });

// // fail
// app.MapPost("jobexecute-c", [Topic("batch-param", "job-c-params")] ([FromBody] EmptyJobParams param) => {
//     Console.WriteLine($"jobexecute C. job is fail");
//     return Results.Problem("job is fail");
// });

// // heavy
// app.MapPost("jobexecute-d", [Topic("batch-param", "job-d-params")] ([FromBody] EmptyJobParams param) => {
//     Console.WriteLine($"jobexecute D. job is heavy");
//     for (var i = 0; i < 10; i++)
//     {
//         for (var j = 0; j < 60; j++)
//         {
//             Thread.Sleep(1000);
//             Console.WriteLine($"executing... {(i * 60) + j}");
//         }
//     }
//     Console.WriteLine($"jobexecute D is end");
//     return Results.Ok;
// });

await app.RunAsync();

class JobAParams
{
    public int Order { get; set; }
}

class EmptyJobParams
{
}