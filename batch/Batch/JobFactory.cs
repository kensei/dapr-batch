using DaprBatch.Batch.Jobs;

namespace DaprBatch.Batch
{
    public class JobFactory
    {
        public static IJobBase CreateJob(EnumBatchJob batchJob)
        {
            switch (batchJob)
            {
                case EnumBatchJob.JobA:
                    return new JobA();
                case EnumBatchJob.JobB:
                    return new JobA();
                case EnumBatchJob.JobC:
                    return new JobA();
                case EnumBatchJob.JobD:
                    return new JobA();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
