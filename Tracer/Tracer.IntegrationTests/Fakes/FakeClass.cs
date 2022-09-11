using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tracer.Core.Interfaces;

namespace Tracer.Example.Fakes
{
    public class FakeClass
    {
        private ITracer _tracer;
    
        public FakeClass(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void OuterTestMethodSingleThread()
        {
            _tracer.StartTrace();
            InnerTestMethod();
            _tracer.StopTrace();
        }

        public void OuterTestMethodMultiThread()
        {
            _tracer.StartTrace();
            var task = Task.Run(() => InnerTestMethod());
            Task.WaitAll(task);
            _tracer.StopTrace();
        }
        
        private void InnerTestMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
        
        private void M2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            M3();
            _tracer.StopTrace();
        }

        private void M3()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
    }
}