using System.Diagnostics;
using System;
using Tracer.Core;
using Tracer.Core.Interfaces;
using Tracer.Example.Fakes;
using Newtonsoft.Json;
using Tracer.Core.Extensions;

ITracer tracer = new StackTracer();

FakeClass fakeClass = new FakeClass(tracer);
Task.Run(() => fakeClass.M0());
fakeClass.M0();

var result = tracer.GetTraceResult();
var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
System.Console.WriteLine(json);