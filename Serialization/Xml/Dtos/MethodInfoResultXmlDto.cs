using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization.XmlSerializer.Dtos
{
    [Serializable]
    [XmlType("Method")]
    public class MethodInfoResultXmlDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public long ExecutionTime { get; set; }
        public List<MethodInfoResultXmlDto> Methods { get; set; }
    }
}