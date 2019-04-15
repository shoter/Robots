using Moq;
using Robots.Core.ProgramExecution;
using Robots.Core.Programs;
using Robots.Gui.State;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.State
{
    public class ApplicationStateTests
    {
        private IApplicationState applicationState;

        private readonly Mock<IRobotFactory> robotFactoryMock = new Mock<IRobotFactory>();

        private readonly Mock<IProgramExecutionService> programExecutionServiceMock = new Mock<IProgramExecutionService>();

        public ApplicationStateTests()
        {
            this.applicationState = new ApplicationState(robotFactoryMock.Object, programExecutionServiceMock.Object);
        }

        [Fact]
        public void AfterConstructor_NoProgramsAtStart()
        {
            Assert.Empty(applicationState.Programs);
        }

        [Fact]
        public void AfterConstructor_RobotShouldBeTakenFromFactory()
        {
            List<IRobot> robots = new List<IRobot>();

            for(int i = 0; i < 13; ++i)
            {
                robots.Add(new Mock<IRobot>().Object);
            }

            robotFactoryMock.Setup(x => x.GetRegisteredRobots()).Returns(robots);
            applicationState = new ApplicationState(robotFactoryMock.Object, programExecutionServiceMock.Object);

            foreach(var robot in robots)
            {
                Assert.Contains(applicationState.Robots, r => r.Robot == robot);
            }
            Assert.Equal(robots.Count, applicationState.Robots.Count());
        }

        [Fact]
        public void AddProgram_ShouldAddProgram()
        {
            var program = new Mock<IProgram>().Object;
            applicationState.AddProgram(program);

            Assert.Single(applicationState.Programs, program);
        }

        [Fact]
        public void RemoveProgram_ShouldRemoveProgram()
        {
            var program = new Mock<IProgram>().Object;

            applicationState.AddProgram(program);
            applicationState.RemoveProgram(program);

            Assert.Empty(applicationState.Programs);
        }
    }
}
