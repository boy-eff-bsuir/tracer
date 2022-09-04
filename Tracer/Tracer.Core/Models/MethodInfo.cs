using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class MethodInfo
    {
        public MethodInfo(string name, string className, int executionTime)
        {
            Name = name;
            ClassName = className;
            ExecutionTime = executionTime;
        }

        public string Name { get; set; }
        public string ClassName { get; set; }
        public int ExecutionTime { get; set; }
    }
}