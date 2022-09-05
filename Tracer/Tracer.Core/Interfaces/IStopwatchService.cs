using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Interfaces
{
    public interface IStopwatchService
    {
        public bool Start(Guid id);
          public long Stop(Guid id);
    }
}