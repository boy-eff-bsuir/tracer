using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    public class MethodInfo
    {
        public MethodInfo(string name, string className)
        {
            Id = Guid.NewGuid();
            Name = name;
            ClassName = className;
        }

        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("className")]
        public string ClassName { get; set; }
        [JsonProperty("executionTime")]
        public long ExecutionTime { get; set; }
    }
}