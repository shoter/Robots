using Moq;
using Robots.Core.Programs;
using Robots.SDK;
using System.Windows.Input;
using Xunit;

namespace Robots.Core.Test.UnitTests.Programs
{
    public class TurnCommandUnitTests
    {
        [Fact]
        public void Execute_ShouldInvokeTurnOnRobot()
        {
            IProgramCommand command = new TurnCommand(90);
            var robotMock = new Mock<IRobot>();

            command.Execute(robotMock.Object);

            robotMock.Verify(x => x.Turn(90), Times.Once);
        }

        [Fact]
        public void Describe_ShouldWaryDependingOnAngle()
        {
            IProgramCommand firstCommand = new TurnCommand(90);
            IProgramCommand secondCommand = new TurnCommand(123);

            Assert.NotEqual(firstCommand.Describe(), secondCommand.Describe());
        }

        [Fact]
        public void Describe_ShouldBeNotEmpty()
        {
            IProgramCommand command = new TurnCommand(123);

            Assert.False(string.IsNullOrWhiteSpace(command.Describe()));
        }
    }
}
