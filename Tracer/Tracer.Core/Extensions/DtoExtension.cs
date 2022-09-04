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
        public static TreeDto ToDto(this Tree<MethodInfo> tree)
        {
            return new TreeDto
            {
                Id = tree.Id,
                TotalTime = tree.Root.Children.Sum(x => x.Data.ExecutionTime),
                Methods = tree.Root.Children
            };
        }
    }
}