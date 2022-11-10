using System.Text.Json;

namespace DaprBatch.Batch
{
    public abstract class AbstractJobBase<T> : IJobBase where T : new()
    {
        public async Task<IJobResult> ExecuteJob(string jobParamJson)
        {
            try
            {
                var param = JsonSerializer.Deserialize<T>(jobParamJson)!;
                var result = await Execute(param);
                return result;
            }
            catch (Exception e)
            {
                return new JobFailResult(){ Message = e.Message };
            }
        }

        protected abstract Task<IJobResult> Execute(T jobParamJson);
    }
}
