using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Core.Services
{
    public class StopwatchService
    {
       private static Dictionary<Guid, Stopwatch> _stopwatches = new Dictionary<Guid, Stopwatch>();

       public static void Start(Guid id)
       {
            _stopwatches.Add(id, new Stopwatch());
            _stopwatches[id].Start();
       }

       public static long Stop(Guid id)
       {
            var stopwatch = _stopwatches[id];
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
       }
    }
}