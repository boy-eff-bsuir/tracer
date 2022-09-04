using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Models;

namespace Tracer.Core.Interfaces
{
    public interface ITracer 
    {
        // вызывается в начале замеряемого метода
        void StartTrace();

        // вызывается в конце замеряемого метода
        void StopTrace();

        // получить результаты измерений
        TraceResult GetTraceResult();
    }
}