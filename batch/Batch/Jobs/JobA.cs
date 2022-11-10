using DaprBatch.Batch;

namespace DaprBatch.Batch.Jobs
{
    public class JobAParams : IJobParam
    {
        public int Order { get; set; }
    }

    public class JobA : AbstractJobBase<JobAParams>
    {
        protected override async Task<IJobResult> Execute(JobAParams jobParamJson)
        {
            return await Task.FromResult<IJobResult>(new JobSuccessResult() { BatchJob = EnumBatchJob.JobA });
        }
    }
}