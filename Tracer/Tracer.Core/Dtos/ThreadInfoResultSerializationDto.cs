using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Tracer.Core.Models;

namespace Tracer.Core.Dtos
{
    [Serializable]
    public class ThreadInfoResultSerializationDto
    {
        [JsonProperty("id")]
        public int ThreadId { get; set; }
        [JsonProperty("time")]
        public long TotalTime { get; set; }
        [JsonProperty("methods")]
        public List<MethodInfoResultSerializationDto> Methods { get; set; }
    }
}