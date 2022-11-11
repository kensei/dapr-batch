namespace DaprBatch.Batch.Jobs
{
    public class JobC : AbstractJobBase<EmptyJobParam>
    {
        protected override Task<IJobResult> Execute(BatchContext context, EmptyJobParam jobParamJson)
        {
            throw new NotImplementedException();
        }
    }
}
