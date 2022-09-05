using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Models;

namespace Tracer.Core.Interfaces
{
    public interface ITraceService
    {
        TraceResult GetResult();
        void Up(long time);
        void Down(MethodInfo info);
        MethodInfo GetCurrentMethod();
    }
}