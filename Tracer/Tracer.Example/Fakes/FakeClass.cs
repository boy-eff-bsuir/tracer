using System;
using System.Collections.Generic;
using System.Linq;
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

        public void M0()
        {
            M1();
            M2();
        }
        
        private void M1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
        
        private void M2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
    }
}