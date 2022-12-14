using System.Net;
using DaprBatch.Batch;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/JobEnqueueA", async (context) => {
    var bodyJson = await GetRequestJson(context.Request);
    Console.WriteLine($"JobA enqueue. param:{bodyJson}");
    var job = JobFactory.CreateJob(EnumBatchJob.JobA);
    var ret = await job.ExecuteJob(bodyJson);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsJsonAsync(new { status = $"{ret}" });
});

app.MapPost("/JobEnqueueB", async (context) => {
    var bodyJson = await GetRequestJson(context.Request);
    Console.WriteLine($"JobB enqueue. param is empty");
    var job = JobFactory.CreateJob(EnumBatchJob.JobB);
    var ret = await job.ExecuteJob(bodyJson);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsJsonAsync(new { status = $"{ret}" });
});

app.MapPost("/JobEnqueueC", async (context) => {
    var bodyJson = await GetRequestJson(context.Request);
    Console.WriteLine($"JobC enqueue. result is fail");
    var job = JobFactory.CreateJob(EnumBatchJob.JobC);
    var ret = await job.ExecuteJob(bodyJson);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsJsonAsync(new { status = $"{ret}" });
});

app.MapPost("/JobEnqueueD", async (context) => {
    var bodyJson = await GetRequestJson(context.Request);
    Console.WriteLine($"JobD enqueue. long job");
    var job = JobFactory.CreateJob(EnumBatchJob.JobD);
    var ret = await job.ExecuteJob(bodyJson);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsJsonAsync(new { status = $"{ret}" });
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

await app.RunAsync();