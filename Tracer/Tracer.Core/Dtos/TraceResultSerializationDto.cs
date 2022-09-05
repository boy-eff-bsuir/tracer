using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Tracer.Core.Dtos
{
    [Serializable]
    public class TraceResultSerializationDto
    {
        public TraceResultSerializationDto()
        {
            
        }
        public TraceResultSerializationDto(List<ThreadInfoResultSerializationDto> threads)
        {
            Threads = threads;
        }
        [JsonProperty("threads")]
        [XmlElement("Threads")]
        public List<ThreadInfoResultSerializationDto> Threads { get; set; }
    }
}