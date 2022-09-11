using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tracer.Core.Models
{
    public class MethodInfoResult
    {
        public MethodInfoResult()
        {
        }

        public MethodInfoResult(Guid id, string name, string className, long executionTime)
        {
            Id = id;
            Name = name;
            ClassName = className;
            ExecutionTime = executionTime;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string ClassName { get; }
        public long ExecutionTime { get; }
        private IReadOnlyList<MethodInfoResult> _methods;
        public IReadOnlyList<MethodInfoResult> Methods { 
            get
            {
                return _methods;
            } 
            set 
            {
                if (_methods == null)
                {
                    _methods = value;
                }
                else
                {
                    throw new Exception("Method value is already set");
                }
        } }
    }
}