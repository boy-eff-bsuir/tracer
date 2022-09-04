using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Extensions;
using Tracer.Core.Interfaces;
using Tracer.Core.Models;
using Tracer.Core.Services;

namespace Tracer.Core
{
    public class StackTracer : ITracer
    {
        private const int LastStackFrameIndex = 1;
        private TraceService _traceService = new TraceService();

        public TraceResult GetTraceResult()
        {
            return _traceService.GetResult();
        }

        public void StartTrace()
        {
            StackTrace _stackTrace = new StackTrace();
            var sf = _stackTrace.GetFrame(LastStackFrameIndex);
            var method = sf.GetMethod();
            var methodInfo = new MethodInfo(method.Name, 
                method.DeclaringType.Name);
            _traceService.Down(methodInfo);

            StopwatchService.Start(methodInfo.Id);
        }

        public void StopTrace()
        {
            var method = _traceService.GetCurrentMethod();
            var time = StopwatchService.Stop(method.Id);
            _traceService.Up(time);
        }
    }
}