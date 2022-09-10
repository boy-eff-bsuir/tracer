using JsonSerializer.Extensions;
using Serialization.XmlSerializer.Dtos;
using System.Xml.Serialization;
using Tracer.Core.Models;
using Tracer.Serialization.Abstractions;

namespace Xml
{
    public class XmlTraceResultSerializer : ITraceResultSerializer
    {
        public string SerializationFormat { get; } = "xml";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var dto = traceResult.ToDto();
            XmlSerializer serializer = new XmlSerializer(typeof(TraceResultXmlDto));
            serializer.Serialize(to, dto);
        }
    }
}