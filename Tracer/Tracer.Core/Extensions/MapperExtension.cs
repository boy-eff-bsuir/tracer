using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Models;

namespace Tracer.Core.Extensions
{
    public static class DtoExtension
    {
        public static ThreadInfo ToThreadInfo(this Tree<MethodInfo> tree)
        {
            return new ThreadInfo
            {
                ThreadId = tree.Id,
                TotalTime = tree.Root.Children.Sum(x => x.Data.ExecutionTime),
                Methods = tree.Root.Children
            };
        }
    }
}