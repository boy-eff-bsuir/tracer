using System.Diagnostics;
using System;
using Tracer.Core;
using Tracer.Core.Interfaces;
using Tracer.Example.Fakes;

ITracer tracer = new StackTracer();

FakeClass fakeClass = new FakeClass(tracer);

fakeClass.M0();