using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Core.Interfaces;

namespace Tracer.Core.Services
{
    public class StopwatchService : IStopwatchService
    {
          private ConcurrentDictionary<Guid, Stopwatch> _stopwatches 
               = new ConcurrentDictionary<Guid, Stopwatch>();

          public bool Start(Guid id)
          {
               bool result = _stopwatches.TryAdd(id, new Stopwatch());
               if (result)
               {
                    _stopwatches[id].Start();
               }
               return result;
          }
          public long Stop(Guid id)
          {
               if (_stopwatches.ContainsKey(id))
               {
                    var stopwatch = _stopwatches[id];
                    stopwatch.Stop();
                    return stopwatch.ElapsedMilliseconds;
               }
               else
               {
                    return -1;
               }
          }
    }
}