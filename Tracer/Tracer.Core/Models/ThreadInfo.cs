using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    [Serializable]
    public class ThreadInfo
    {
        [JsonProperty("id")]
        public int ThreadId { get; set; }
        [JsonProperty("time")]
        public long TotalTime { get; set; }
        [JsonProperty("methods")]
        public List<Node<MethodInfo>> Methods { get; set; }
    }
}