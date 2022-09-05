using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Tracer.Core;
using Tracer.Core.Interfaces;
using Tracer.Core.Models;
using Tracer.Core.Services;
using Xunit;

namespace Tracer.Tests
{
    public class StackTracerTests
    {
        [Fact]
        public void StartTrace_ShouldThrowExceptionIfMethodIdExists()
        {
            var stopwatchMock = new Mock<IStopwatchService>();
            stopwatchMock.Setup(x => x.Start(It.IsAny<Guid>())).Returns(false);
            var traceMock = new Mock<ITraceService>();
            var sut = new StackTracer(traceMock.Object, stopwatchMock.Object);

            Assert.Throws<Exception>(() => sut.StartTrace());
        }

        [Fact]
        public void StopTrace_ShouldThrowExceptionIfMethodIdExists()
        {
            var stopwatchMock = new Mock<IStopwatchService>();
            stopwatchMock.Setup(x => x.Stop(It.IsAny<Guid>())).Returns(-1);
            var traceMock = new Mock<ITraceService>();
            traceMock.Setup(x => x.GetCurrentMethod()).Returns(new MethodInfo("test", "test"));
            var sut = new StackTracer(traceMock.Object, stopwatchMock.Object);

            Assert.Throws<Exception>(() => sut.StopTrace());
        }

        [Fact]
        public void GetTraceResult_ShouldReturnEmptyResult()
        {
            var stopwatchMock = new Mock<IStopwatchService>();
            var traceMock = new Mock<ITraceService>();
            traceMock.Setup(x => x.GetResult()).Returns(new TraceResult(new List<ThreadInfoResult>()));
            var sut = new StackTracer(traceMock.Object, stopwatchMock.Object);

            var result = sut.GetTraceResult();
            Assert.Empty(result.Threads);
        }

        [Fact]
        public void GetTraceResult_ShouldCallTraceServiceOnce()
        {
            var stopwatchMock = new Mock<IStopwatchService>();
            var traceMock = new Mock<ITraceService>();
            traceMock.Setup(x => x.GetResult()).Returns(new TraceResult(new List<ThreadInfoResult>()));
            var sut = new StackTracer(traceMock.Object, stopwatchMock.Object);

            var result = sut.GetTraceResult();
            traceMock.Verify(x => x.GetResult(), Times.Once);
        }
    }
}