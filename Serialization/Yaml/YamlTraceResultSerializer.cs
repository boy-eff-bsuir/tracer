using JsonSerializer.Extensions;
using System.Text;
using Tracer.Core.Models;
using Tracer.Serialization.Abstractions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Yaml
{
    public class YamlTraceResultSerializer : ITraceResultSerializer
    {
        public string SerializationType { get; } = "Yaml";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var dto = traceResult.ToDto();
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(dto);
            to.Write(Encoding.Default.GetBytes(yaml));
        }
    }
}