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
    [Serializable]
    public class TraceResult
    {
        public TraceResult()
        {
            
        }
        public TraceResult(List<ThreadInfoResultSerializationDto> threads)
        {
            Threads = threads;
        }
        [JsonProperty("threads")]
        [XmlElement("Threads")]
        public List<ThreadInfoResultSerializationDto> Threads { get; set; }
    }
}