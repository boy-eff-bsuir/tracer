using JsonSerializer.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.Dtos;
using Tracer.Core.Models;
using Tracer.Serialization.Abstractions;

namespace Json
{
    public class JsonTraceResultSerializer : ITraceResultSerializer
    {
        public string SerializationType { get; } = "Json";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var dto = traceResult.ToDto();
            var json = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            to.Write(Encoding.Default.GetBytes(json));
        }
    }
}