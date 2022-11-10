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
                    return new JobB();
                case EnumBatchJob.JobC:
                    return new JobC();
                case EnumBatchJob.JobD:
                    return new JobD();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
