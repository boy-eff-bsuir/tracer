using Serialization.JsonSerializer.Dtos;
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
        public static MethodInfoResultJsonDto ToDto(this MethodInfoResult result)
        {
            return new MethodInfoResultJsonDto()
            {
                Id = result.Id,
                Name = result.Name,
                ClassName = result.ClassName,
                ExecutionTime = result.ExecutionTime
            };
        }

        public static TraceResultJsonDto ToDto(this TraceResult result)
        {
            return new TraceResultJsonDto(result.Threads.Select(x => x.ToDto()).ToList());
        }


        public static ThreadInfoResultJsonDto ToDto(this ThreadInfoResult result)
        {
            var dto = new MethodInfoResultJsonDto();
            var root = new MethodInfoResult()
            {
                Methods = result.Methods.ToList()
            };
            TraverseMethodResultToDto(root, dto);

            return new ThreadInfoResultJsonDto
            {
                ThreadId = result.ThreadId,
                TotalTime = result.TotalTime,
                Methods = dto.Methods
            };
        }

        private static void TraverseMethodResultToDto(MethodInfoResult result, MethodInfoResultJsonDto dto)
        {
            dto.Methods = result.Methods.Select(x => x.ToDto()).ToList();

            for (int i = 0; i < result.Methods.Count; i++)
            {
                TraverseMethodResultToDto(result.Methods[i], dto.Methods[i]);
            }
        }
    }
}
