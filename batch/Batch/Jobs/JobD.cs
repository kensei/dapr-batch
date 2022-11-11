namespace DaprBatch.Batch.Jobs
{
    public class JobD : AbstractJobBase<EmptyJobParam>
    {
        protected override async Task<IJobResult> Execute(BatchContext context, EmptyJobParam jobParamJson)
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 60; j++)
                {
                    await Task.Delay(1000);
                    Console.WriteLine($"executing... {(i * 60) + j}");
                }
            }
            return await Task.FromResult<IJobResult>(new JobSuccessResult() { BatchJob = EnumBatchJob.JobD });
        }
    }
}
