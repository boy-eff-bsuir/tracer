using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.Models;
using Tracer.Serialization.Abstractions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Yaml
{
    public class YamlTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(traceResult);
            to.Write(Encoding.Default.GetBytes(yaml));
        }
    }
}