using Tracer.Core;
using Tracer.Core.Interfaces;
using Tracer.Example.Fakes;
using Tracer.Core.Services;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Tracer.Core.Models;

int streamSize = 2000;
IStopwatchService stopwatchService = new StopwatchService();
ITraceService traceService = new TraceService();
ITracer tracer = new StackTracer(traceService, stopwatchService);

FakeClass fakeClass = new FakeClass(tracer);
Task.Run(() => fakeClass.M0());
fakeClass.M0();

var result = tracer.GetTraceResult();

var assemblyJson = Assembly.LoadFrom(@"C:\Users\Asus\Desktop\5 семестр\СПП\1 лаба\Serialization\Json\bin\Debug\net6.0\JsonSerializer.dll");
var assemblyXml = Assembly.LoadFrom(@"C:\Users\Asus\Desktop\5 семестр\СПП\1 лаба\Serialization\Xml\bin\Debug\net6.0\XmlSerializer.dll");


var typeJson = assemblyJson.GetType("Json.JsonTraceResultSerializer");
var typeXml = assemblyXml.GetType("Xml.XmlTraceResultSerializer");

var methodJson = typeJson.GetMethod("Serialize");
var methodXml = typeXml.GetMethod("Serialize");



object obj = Activator.CreateInstance(typeXml);
using (var memoryStream = new MemoryStream(streamSize))
{
    methodXml.Invoke(obj, new object[] { result, memoryStream });
    memoryStream.Seek(0, SeekOrigin.Begin);
    var bytes = new byte[streamSize];
    memoryStream.Read(bytes, 0, streamSize);
    System.Console.WriteLine(Encoding.Default.GetString(bytes));
}
