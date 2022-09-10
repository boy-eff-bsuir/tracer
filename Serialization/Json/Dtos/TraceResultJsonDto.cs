using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization.JsonSerializer.Dtos
{
    [Serializable]
    public class TraceResultJsonDto
    {
        public TraceResultJsonDto()
        {
            
        }
        public TraceResultJsonDto(List<ThreadInfoResultJsonDto> threads)
        {
            Threads = threads;
        }
        [JsonProperty("threads")]
        public List<ThreadInfoResultJsonDto> Threads { get; set; }
    }
}