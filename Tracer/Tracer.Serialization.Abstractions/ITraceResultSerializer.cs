using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Serialization.Abstractions
{
    public interface ITraceResultSerializer
    {
        void Serialize(TraceResult traceResult, Stream to);
    }
}