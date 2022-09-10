using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization.YamlSerializer.Dtos
{
    [Serializable]
    public class TraceResultYamlDto
    {
        public TraceResultYamlDto()
        {
            
        }
        public TraceResultYamlDto(List<ThreadInfoResultYamlDto> threads)
        {
            Threads = threads;
        }
        public List<ThreadInfoResultYamlDto> Threads { get; set; }
    }
}