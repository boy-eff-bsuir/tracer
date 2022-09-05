using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Tracer.Core.Services;
using Xunit;

namespace Tracer.Tests
{
    public class StopwatchServiceTests
    {
        [Fact] 
        public void Start_ShouldReturnTrueIfValid()
        {
            var sut = new StopwatchService();
            var id = Guid.NewGuid();

            var result = sut.Start(id);

            result.Should().Be(true);
        }

        [Fact]
        public void Start_ShouldReturnFalseIfNotValid()
        {
            var sut = new StopwatchService();
            var id = Guid.NewGuid();
            sut.Start(id);

            var result = sut.Start(id);

            result.Should().Be(false);
        }

        [Fact]
        public void Stop_ShouldReturnPositiveIfGuidExists()
        {
            var sut = new StopwatchService();
            var id = Guid.NewGuid();
            sut.Start(id);

            var result = sut.Stop(id);

            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public void Stop_ShouldReturnNegativeIfGuidDoesNotExist()
        {
            var sut = new StopwatchService();
            var id = Guid.NewGuid();

            var result = sut.Stop(id);

            result.Should().BeLessThan(0);
        }
    }
}