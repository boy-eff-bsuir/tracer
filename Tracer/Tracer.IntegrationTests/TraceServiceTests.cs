using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Tracer.Core;
using Tracer.Core.Models;
using Tracer.Core.Services;
using Tracer.Example.Fakes;
using Xunit;

namespace Tracer.IntegrationTests;

public class TraceServiceTests
{
    [Fact]
    public void ShouldContainOneThread()
    {
        var stopwatchService = new StopwatchService();
        var traceService = new TraceService();
        var sut = new StackTracer(traceService, stopwatchService);
        var fakeClass = new FakeClass(sut);

        fakeClass.OuterTestMethodSingleThread();
        var result = sut.GetTraceResult();

        result.Threads.Count.Should().Be(1);
    }

    [Fact]
    public void ShouldContainValidThreadId()
    {
        var stopwatchService = new StopwatchService();
        var traceService = new TraceService();
        var sut = new StackTracer(traceService, stopwatchService);
        var fakeClass = new FakeClass(sut);
        var id = Thread.CurrentThread.ManagedThreadId;

        fakeClass.OuterTestMethodSingleThread();
        var result = sut.GetTraceResult();

        result.Threads.Count.Should().Be(1);
        result.Threads[0].ThreadId.Should().Be(id);
    }

    [Fact]
    public void ShouldContainTwoThreadsAsync()
    {
        var stopwatchService = new StopwatchService();
        var traceService = new TraceService();
        var sut = new StackTracer(traceService, stopwatchService);
        var fakeClass = new FakeClass(sut);

        fakeClass.OuterTestMethodMultiThread();
        var result = sut.GetTraceResult();

        result.Threads.Count.Should().BeGreaterThan(1);
    }

    [Fact]
    public void TotalTimeShouldBeEqualToSumOfTimes()
    {
        var stopwatchService = new StopwatchService();
        var traceService = new TraceService();
        var sut = new StackTracer(traceService, stopwatchService);
        var fakeClass = new FakeClass(sut);

        fakeClass.OuterTestMethodMultiThread();
        var result = sut.GetTraceResult();

        long totalTime = result.Threads.Sum(thread => thread.TotalTime);
        long sumTime = 0;
        result.Threads.ToList().ForEach(
            thread => thread.Methods.ToList().ForEach(
                method => sumTime += method.ExecutionTime
            )
        );

        totalTime.Should().BeGreaterThanOrEqualTo(sumTime);
    }

    [Fact]
    public void ShouldContainValidMethodName()
    {
        var stopwatchService = new StopwatchService();
        var traceService = new TraceService();
        var sut = new StackTracer(traceService, stopwatchService);
        var fakeClass = new FakeClass(sut);
        var methodName = nameof(fakeClass.OuterTestMethodSingleThread);

        fakeClass.OuterTestMethodSingleThread();
        var result = sut.GetTraceResult();

        result.Threads.Count.Should().Be(1);
        result.Threads[0].Methods.Select(method => method.Name).Should().Contain(methodName);
    }

    [Fact]
    public void ShouldContainValidClassName()
    {
        var stopwatchService = new StopwatchService();
        var traceService = new TraceService();
        var sut = new StackTracer(traceService, stopwatchService);
        var fakeClass = new FakeClass(sut);
        var className = nameof(FakeClass);

        fakeClass.OuterTestMethodSingleThread();
        var result = sut.GetTraceResult();

        result.Threads.Count.Should().Be(1);
        result.Threads[0].Methods.Select(method => method.ClassName).Should().Contain(className);
    }
}