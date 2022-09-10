using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization.JsonSerializer.Dtos
{
    [Serializable]
    public class ThreadInfoResultJsonDto
    {
        [JsonProperty("id")]
        public int ThreadId { get; set; }
        [JsonProperty("time")]
        public long TotalTime { get; set; }
        [JsonProperty("methods")]
        public List<MethodInfoResultJsonDto> Methods { get; set; }
    }
}