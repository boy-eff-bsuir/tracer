using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    public class ThreadInfoResult
    {
        public int ThreadId { get; set; }
        public long TotalTime { get; set; }
        public IReadOnlyList<MethodInfoResult> Methods { get; set; }
    }
}