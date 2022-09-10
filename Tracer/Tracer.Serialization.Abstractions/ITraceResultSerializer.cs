using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Models;

namespace Tracer.Serialization.Abstractions
{
    public interface ITraceResultSerializer
    {
        string SerializationFormat { get; }
        void Serialize(TraceResult traceResult, Stream to);
    }
}