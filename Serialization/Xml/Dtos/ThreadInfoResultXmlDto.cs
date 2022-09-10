using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization.XmlSerializer.Dtos
{
    [Serializable]
    public class ThreadInfoResultXmlDto
    {
        public int ThreadId { get; set; }
        public long TotalTime { get; set; }
        public List<MethodInfoResultXmlDto> Methods { get; set; }
    }
}