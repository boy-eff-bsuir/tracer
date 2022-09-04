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
        private TraceResult _traceResult = new TraceResult();
        private Stack<MethodInfo> _currentStack { get; set; } = new Stack<MethodInfo>();
        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }

        public void StartTrace()
        {
            StackTrace _stackTrace = new StackTrace();
            var sf = _stackTrace.GetFrame(_stackTrace.FrameCount - 3);
            var method = sf.GetMethod();
            _currentStack.Push(new MethodInfo(method.Name, 
                method.DeclaringType.Name, 100)
            );

            System.Console.WriteLine(method.Name);
            System.Console.WriteLine(method.DeclaringType.Name);
            System.Console.WriteLine();
        }

        public void StopTrace()
        {
            var methodInfo = _currentStack.Pop();
            _traceResult.Tree.CreateChild(methodInfo);
        }
    }
}