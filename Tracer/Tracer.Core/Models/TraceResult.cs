using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    public class TraceResult
    {
        public TraceResult(IReadOnlyList<ThreadInfo> threads)
        {
            Threads = threads;
        }
        [JsonProperty("threads")]
        IReadOnlyList<ThreadInfo> Threads { get; set; }
    }
}