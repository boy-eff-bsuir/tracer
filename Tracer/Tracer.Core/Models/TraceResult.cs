namespace Tracer.Core.Models
{
    public class TraceResult
    {
        public TraceResult(List<ThreadInfoResult> threads)
        {
            Threads = threads;
        }
        public IReadOnlyList<ThreadInfoResult> Threads { get; }
    }
}