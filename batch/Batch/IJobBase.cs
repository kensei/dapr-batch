namespace DaprBatch.Batch
{
    public interface IJobBase
    {
        Task<IJobResult> ExecuteJob(string jobParamJson);
    }
}
