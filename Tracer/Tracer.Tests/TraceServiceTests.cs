using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Tracer.Core.Models;
using Tracer.Core.Services;
using Xunit;

namespace Tracer.Tests
{
    public class TraceServiceTests
    {
        [Fact]
        public void Up_ShouldReturnFalseIfTimeIsNotValid()
        {
            var sut = new TraceService();

            var result = sut.Up(-1);

            result.Should().BeFalse();
        }

        [Fact]
        public void Up_ShouldReturnFalseIfCurrentNodeIsRoot()
        {
            var sut = new TraceService();

            var result = sut.Up(1);

            result.Should().BeFalse();
        }
    }
}