using System.Diagnostics;
using System;
using Tracer.Core;
using Tracer.Core.Interfaces;
using Tracer.Example.Fakes;
using Newtonsoft.Json;

ITracer tracer = new StackTracer();

FakeClass fakeClass = new FakeClass(tracer);

fakeClass.M0();
var result = tracer.GetTraceResult().Result;
var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
System.Console.WriteLine(json);