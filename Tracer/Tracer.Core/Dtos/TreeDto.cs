using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tracer.Core.Models;

namespace Tracer.Core.Dtos
{
    public class TreeDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("time")]
        public long TotalTime { get; set; }
        [JsonProperty("methods")]
        public List<Node<MethodInfo>> Methods { get; set; }
    }
}