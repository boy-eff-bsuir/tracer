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
        private ITraceService _traceService;
        private IStopwatchService _stopwatchService;
        public StackTracer(ITraceService traceService, IStopwatchService stopwatchService)
        {
            _traceService = traceService;
            _stopwatchService = stopwatchService;
        }

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

            var result = _stopwatchService.Start(methodInfo.Id);
            if (!result)
            {
                throw new Exception(nameof(StackTracer));
            }
        }

        public void StopTrace()
        {
            var method = _traceService.GetCurrentMethod();
            var time = _stopwatchService.Stop(method.Id);
            if (time < 0)
            {
                throw new Exception(nameof(StackTracer));
            }
            _traceService.Up(time);
        }
    }
}