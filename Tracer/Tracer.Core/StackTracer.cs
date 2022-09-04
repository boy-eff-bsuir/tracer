using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Interfaces;
using Tracer.Core.Models;
using Tracer.Core.Services;

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
            var methodInfo = new MethodInfo(method.Name, 
                method.DeclaringType.Name);
            _traceResult.Down(methodInfo);

            StopwatchService.Start(methodInfo.Id);
        }

        public void StopTrace()
        {
            var method = _traceResult.GetCurrentMethod();
            var time = StopwatchService.Stop(method.Id);
            _traceResult.Up(time);
        }
    }
}