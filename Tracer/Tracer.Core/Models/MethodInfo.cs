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
            Name = name;
            ClassName = className;
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("className")]
        public string ClassName { get; set; }
        [JsonProperty("executionTime")]
        public int ExecutionTime { get; set; }
    }
}