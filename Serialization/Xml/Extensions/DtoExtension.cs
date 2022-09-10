using Serialization.XmlSerializer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.Models;

namespace JsonSerializer.Extensions
{
    internal static class DtoExtension
    {
        public static MethodInfoResultXmlDto ToDto(this MethodInfoResult result)
        {
            return new MethodInfoResultXmlDto()
            {
                Id = result.Id,
                Name = result.Name,
                ClassName = result.ClassName,
                ExecutionTime = result.ExecutionTime
            };
        }

        public static TraceResultXmlDto ToDto(this TraceResult result)
        {
            return new TraceResultXmlDto(result.Threads.Select(x => x.ToDto()).ToList());
        }


        public static ThreadInfoResultXmlDto ToDto(this ThreadInfoResult result)
        {
            var dto = new MethodInfoResultXmlDto();
            var root = new MethodInfoResult()
            {
                Methods = result.Methods.ToList()
            };
            TraverseMethodResultToDto(root, dto);

            return new ThreadInfoResultXmlDto
            {
                ThreadId = result.ThreadId,
                TotalTime = result.TotalTime,
                Methods = dto.Methods
            };
        }

        private static void TraverseMethodResultToDto(MethodInfoResult result, MethodInfoResultXmlDto dto)
        {
            dto.Methods = result.Methods.Select(x => x.ToDto()).ToList();

            for (int i = 0; i < result.Methods.Count; i++)
            {
                TraverseMethodResultToDto(result.Methods[i], dto.Methods[i]);
            }
        }
    }
}
