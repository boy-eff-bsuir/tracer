using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization.JsonSerializer.Dtos
{
    [Serializable]
    public class MethodInfoResultJsonDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("className")]
        public string ClassName { get; set; }
        [JsonProperty("executionTime")]
        public long ExecutionTime { get; set; }
        [JsonProperty("methods")]
        public List<MethodInfoResultJsonDto> Methods { get; set; }
    }
}