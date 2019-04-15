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
    public class MoveCommandUnitTests
    {
        [Fact]
        public void Execute_ShouldInvokeMoveOnRobot()
        {
            IProgramCommand command = new MoveCommand(90);
            var robotMock = new Mock<IRobot>();

            command.Execute(robotMock.Object);

            robotMock.Verify(x => x.Move(90), Times.Once);
        }

        [Fact]
        public void Describe_ShouldWaryDependingOnAngle()
        {
            IProgramCommand firstCommand = new MoveCommand(90);
            IProgramCommand secondCommand = new MoveCommand(123);

            Assert.NotEqual(firstCommand.Describe(), secondCommand.Describe());
        }

        [Fact]
        public void Describe_ShouldBeNotEmpty()
        {
            IProgramCommand command = new MoveCommand(123);

            Assert.False(string.IsNullOrWhiteSpace(command.Describe()));
        }
    }
}
