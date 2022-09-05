using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Dtos;
using Tracer.Core.Models;

namespace Tracer.Serialization.Abstractions
{
    public interface ITraceResultSerializer
    {
        void Serialize(TraceResultSerializationDto traceResult, Stream to);
    }
}