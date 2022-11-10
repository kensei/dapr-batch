namespace DaprBatch.Batch
{
    public class JobSuccessResult : IJobResult
    {
        public EnumBatchJob BatchJob { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return $"success : {BatchJob.ToString()}";
        }
    }
}
