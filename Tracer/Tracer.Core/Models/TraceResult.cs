using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Tracer.Core.Dtos;

namespace Tracer.Core.Models
{
    public class TraceResult
    {
        public TraceResult(List<ThreadInfoResult> threads)
        {
            Threads = threads;
        }
        public IReadOnlyList<ThreadInfoResult> Threads { get; set; }
    }
}