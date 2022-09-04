using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Interfaces;
using Tracer.Core.Models;

namespace Tracer.Core
{
    public class StackTracer : ITracer
    {
        private const int LastStackFrameIndex = 1;
        private TraceResult _traceResult = new TraceResult();

        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }

        public void StartTrace()
        {
            StackTrace _stackTrace = new StackTrace();
            var sf = _stackTrace.GetFrame(LastStackFrameIndex);
            var method = sf.GetMethod();

            _traceResult.Down(new MethodInfo(method.Name, 
                method.DeclaringType.Name, 100));

            System.Console.WriteLine(method.Name);
            System.Console.WriteLine(method.DeclaringType.Name);
            System.Console.WriteLine();
        }

        public void StopTrace()
        {
            _traceResult.Up();
        }
    }
}