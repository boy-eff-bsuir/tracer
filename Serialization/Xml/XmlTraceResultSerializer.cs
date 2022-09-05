using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tracer.Serialization.Abstractions;
using Tracer.Core.Dtos;

namespace Xml
{
    public class XmlTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(TraceResultSerializationDto traceResult, Stream to)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TraceResultSerializationDto));
            serializer.Serialize(to, traceResult);
        }
    }
}