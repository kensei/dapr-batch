namespace DaprBatch.Batch
{
    public class JobFailResult : IJobResult
    {
        public int ErrorCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return $"fail : {Message}";
        }
    }
}
