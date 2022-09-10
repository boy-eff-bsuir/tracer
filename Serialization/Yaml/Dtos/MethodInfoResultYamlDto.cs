using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization.YamlSerializer.Dtos
{
    [Serializable]
    public class MethodInfoResultYamlDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public long ExecutionTime { get; set; }
        public List<MethodInfoResultYamlDto> Methods { get; set; }
    }
}