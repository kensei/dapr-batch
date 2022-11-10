namespace DaprBatch.Batch.Jobs
{
    public class JobB : AbstractJobBase<EmptyJobParam>
    {
        protected override async Task<IJobResult> Execute(EmptyJobParam jobParamJson)
        {
            return await Task.FromResult<IJobResult>(new JobSuccessResult() { BatchJob = EnumBatchJob.JobB });
        }
    }
}