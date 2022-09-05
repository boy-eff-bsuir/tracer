using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    [Serializable]
    public class TraceResult
    {
        public TraceResult()
        {
            
        }
        public TraceResult(List<ThreadInfo> threads)
        {
            Threads = threads;
        }

        [JsonProperty("threads")]
        [XmlElement("Threads")]
        public List<ThreadInfo> Threads { get; set; }
    }
}