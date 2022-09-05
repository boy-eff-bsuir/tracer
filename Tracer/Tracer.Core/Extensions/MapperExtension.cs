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
            return new MethodInfoResult(
                method.Id,
                method.Name,
                method.ClassName,
                method.ExecutionTime
            );
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
            TraverseMethodInfoToResult(node, result);

            return new ThreadInfoResult(
                tree.Id,
                tree.Root.Children.Sum(x => x.Data.ExecutionTime),
                result.Methods
            );
        }
        
        public static ThreadInfoResultSerializationDto ToDto(this ThreadInfoResult result)
        {
            var dto = new MethodInfoResultSerializationDto();
            var root = new MethodInfoResult()
            {
                Methods = result.Methods.ToList()
            };
            TraverseMethodResultToDto(root, dto);

            return new ThreadInfoResultSerializationDto
            {
                ThreadId = result.ThreadId,
                TotalTime = result.TotalTime,
                Methods = dto.Methods
            };
        }

        private static void TraverseMethodInfoToResult(Node<MethodInfo> info, MethodInfoResult result)
        {
            result.Methods = info.Children.Select(
                x => x.Data.ToMethodInfoResult()).ToList().AsReadOnly();

            for (int i = 0; i < info.Children.Count; i++)
            {
                TraverseMethodInfoToResult(info.Children[i], result.Methods[i]);
            }
        }

        private static void TraverseMethodResultToDto(MethodInfoResult result, MethodInfoResultSerializationDto dto)
        {
            dto.Methods = result.Methods.Select(x => x.ToDto()).ToList();

            for (int i = 0; i < result.Methods.Count; i++)
            {
                TraverseMethodResultToDto(result.Methods[i], dto.Methods[i]);
            }
        }
    }
}