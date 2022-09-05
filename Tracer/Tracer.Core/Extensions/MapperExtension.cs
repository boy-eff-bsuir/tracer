using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Dtos;
using Tracer.Core.Models;

namespace Tracer.Core.Extensions
{
    public static class DtoExtension
    {
        public static MethodInfoResult ToMethodInfoResult(this MethodInfo method)
        {
            return new MethodInfoResult()
            {
                Id = method.Id,
                Name = method.Name,
                ClassName = method.ClassName,
                ExecutionTime = method.ExecutionTime
            };
        }

        public static MethodInfoResultSerializationDto ToDto(this MethodInfoResult result)
        {
            return new MethodInfoResultSerializationDto()
            {
                Id = result.Id,
                Name = result.Name,
                ClassName = result.ClassName,
                ExecutionTime = result.ExecutionTime
            };
        }

        public static TraceResultSerializationDto ToDto(this TraceResult result)
        {
            return new TraceResultSerializationDto(result.Threads.Select(x => x.ToDto()).ToList());
        }


        public static ThreadInfoResult ToThreadInfoResult(this Tree<MethodInfo> tree)
        {
            var node = tree.Root;
            var result = new MethodInfoResult();
            TraverseToResult(node, result);

            return new ThreadInfoResult
            {
                ThreadId = tree.Id,
                TotalTime = tree.Root.Children.Sum(x => x.Data.ExecutionTime),
                Methods = result.Methods
            };
        }
        
        public static ThreadInfoResultSerializationDto ToDto(this ThreadInfoResult result)
        {
            var dto = new MethodInfoResultSerializationDto();
            var root = new MethodInfoResult()
            {
                Methods = result.Methods.ToList()
            };
            TraverseToDto(root, dto);

            return new ThreadInfoResultSerializationDto
            {
                ThreadId = result.ThreadId,
                TotalTime = result.TotalTime,
                Methods = dto.Methods
            };
        }

        public static void TraverseToResult(Node<MethodInfo> info, MethodInfoResult result)
        {
            result.Methods = info.Children.Select(
                x => x.Data.ToMethodInfoResult()).ToList().AsReadOnly();

            for (int i = 0; i < info.Children.Count; i++)
            {
                TraverseToResult(info.Children[i], result.Methods[i]);
            }
        }

        public static void TraverseToDto(MethodInfoResult result, MethodInfoResultSerializationDto dto)
        {
            dto.Methods = result.Methods.Select(x => x.ToDto()).ToList();

            for (int i = 0; i < result.Methods.Count; i++)
            {
                TraverseToDto(result.Methods[i], dto.Methods[i]);
            }
        }

        
    }
}