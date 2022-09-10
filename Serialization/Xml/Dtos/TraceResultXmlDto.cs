using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization.XmlSerializer.Dtos
{
    [Serializable]
    public class TraceResultXmlDto
    {
        public TraceResultXmlDto()
        {
            
        }
        public TraceResultXmlDto(List<ThreadInfoResultXmlDto> threads)
        {
            Threads = threads;
        }
        [XmlElement("Threads")]
        public List<ThreadInfoResultXmlDto> Threads { get; set; }
    }
}