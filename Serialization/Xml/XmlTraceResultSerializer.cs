using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tracer.Core.Models;
using Tracer.Serialization.Abstractions;

namespace Xml
{
    public class XmlTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TraceResult));
            serializer.Serialize(to, traceResult);
        }
    }
}