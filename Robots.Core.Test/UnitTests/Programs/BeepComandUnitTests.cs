using Moq;
using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Core.Test.UnitTests.Programs
{
    public class BeepComandUnitTests
    {
        [Fact]
        public void Execute_ShouldCallBeep()
        {
            var command = new BeepCommand();
            var robotMock = new Mock<IRobot>();

            command.Execute(robotMock.Object).RunSynchronously();

            robotMock.Verify(x => x.Beep(), Times.Once);
        }

        [Fact]
        public void Describe_ShouldNotBeEmpty()
        {
            var command = new BeepCommand();

            Assert.False(string.IsNullOrWhiteSpace(command.Describe()));
        }
    }
}
