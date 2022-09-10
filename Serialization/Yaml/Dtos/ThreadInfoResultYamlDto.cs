using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization.YamlSerializer.Dtos
{
    [Serializable]
    public class ThreadInfoResultYamlDto
    {
        public int ThreadId { get; set; }
        public long TotalTime { get; set; }
        public List<MethodInfoResultYamlDto> Methods { get; set; }
    }
}