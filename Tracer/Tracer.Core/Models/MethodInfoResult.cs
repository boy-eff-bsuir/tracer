using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    public class MethodInfoResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public long ExecutionTime { get; set; }
        public IReadOnlyList<MethodInfoResult> Methods { get; set; }
    }
}