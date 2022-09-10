using System.Reflection;
using System.Text;
using Tracer.Core;
using Tracer.Core.Interfaces;
using Tracer.Core.Services;
using Tracer.Example.Fakes;
using Tracer.Serialization.Abstractions;

string dllPath = "Serializers";
string methodName = "Serialize";
var interfaceType = typeof(ITraceResultSerializer);


IStopwatchService stopwatchService = new StopwatchService();
ITraceService traceService = new TraceService();
ITracer tracer = new StackTracer(traceService, stopwatchService);

FakeClass fakeClass = new FakeClass(tracer);
Task.Run(() => fakeClass.M0());
fakeClass.M0();

var result = tracer.GetTraceResult();

var files = Directory.GetFiles(dllPath);
foreach (var file in files)
{
    var assembly = Assembly.LoadFrom(file);

    var types = assembly.GetTypes()
        .Where(t => t.GetInterfaces().Contains(interfaceType));

    foreach (var type in types)
    {
        var method = type.GetMethod(methodName);
        var serializer = (ITraceResultSerializer)Activator.CreateInstance(type);
        using (var fileStream = new FileStream($"Results/result.{serializer.SerializationFormat}", FileMode.Create))
        {
            serializer.Serialize(result, fileStream);
        }
    }
}
