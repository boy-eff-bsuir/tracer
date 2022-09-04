using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Models
{
    public class TraceResult
    {
        public Tree<MethodInfo> Tree { get; }
        public TraceResult()
        {
            Tree = new Tree<MethodInfo>(new MethodInfo("root", "root", 0));
        }
    }
}