using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    public class ThreadInfoResult
    {
        public ThreadInfoResult(int threadId, long totalTime, IReadOnlyList<MethodInfoResult> methods)
        {
            ThreadId = threadId;
            TotalTime = totalTime;
            Methods = methods;
        }

        public int ThreadId { get; }
        public long TotalTime { get; }
        public IReadOnlyList<MethodInfoResult> Methods { get; }
    }
}