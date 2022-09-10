using Serialization.YamlSerializer.Dtos;
using Tracer.Core.Models;

namespace JsonSerializer.Extensions
{
    internal static class DtoExtension
    {
        public static MethodInfoResultYamlDto ToDto(this MethodInfoResult result)
        {
            return new MethodInfoResultYamlDto()
            {
                Id = result.Id,
                Name = result.Name,
                ClassName = result.ClassName,
                ExecutionTime = result.ExecutionTime
            };
        }

        public static TraceResultYamlDto ToDto(this TraceResult result)
        {
            return new TraceResultYamlDto(result.Threads.Select(x => x.ToDto()).ToList());
        }


        public static ThreadInfoResultYamlDto ToDto(this ThreadInfoResult result)
        {
            var dto = new MethodInfoResultYamlDto();
            var root = new MethodInfoResult()
            {
                Methods = result.Methods.ToList()
            };
            TraverseMethodResultToDto(root, dto);

            return new ThreadInfoResultYamlDto
            {
                ThreadId = result.ThreadId,
                TotalTime = result.TotalTime,
                Methods = dto.Methods
            };
        }

        private static void TraverseMethodResultToDto(MethodInfoResult result, MethodInfoResultYamlDto dto)
        {
            dto.Methods = result.Methods.Select(x => x.ToDto()).ToList();

            for (int i = 0; i < result.Methods.Count; i++)
            {
                TraverseMethodResultToDto(result.Methods[i], dto.Methods[i]);
            }
        }
    }
}
