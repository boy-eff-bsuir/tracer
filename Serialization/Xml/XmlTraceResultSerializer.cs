using JsonSerializer.Extensions;
using System.Xml.Serialization;
using Tracer.Core.Dtos;
using Tracer.Core.Models;
using Tracer.Serialization.Abstractions;

namespace Xml
{
    public class XmlTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var dto = traceResult.ToDto();
            XmlSerializer serializer = new XmlSerializer(typeof(TraceResultSerializationDto));
            serializer.Serialize(to, dto);
        }
    }
}