using Moq;
using Robots.Core.Programs;
using Robots.Gui.Modules.Robots.RobotList;
using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Robots.RobotList
{
    public class RobotListItemViewModelTests
    {
        private readonly Mock<IRobotState> robotMock = new Mock<IRobotState>();

        private RobotListItemViewModel viewModel;

        public RobotListItemViewModelTests()
        {
            robotMock.SetupGet(x => x.Id).Returns(12345u);
            robotMock.SetupGet(x => x.IsProgramRunning).Returns(false);

            viewModel = new RobotListItemViewModel(robotMock.Object);
        }

        [Fact]
        public void AfterConstructor_ProperValues()
        {
            Assert.Contains(robotMock.Object.Id.ToString(), viewModel.DisplayName);
            Assert.Equal("Idle", viewModel.Status);
        }

        [Fact]
        public void Status_ShouldDisplayProgramNameIfProgramIsRunning()
        {
            robotMock.Setup(x => x.IsProgramRunning).Returns(true);
            var programMock = new Mock<IProgram>();
            programMock.SetupGet(x => x.Name).Returns("This is something");
            robotMock.SetupGet(x => x.AssignedProgram).Returns(programMock.Object);

            Assert.Contains(programMock.Object.Name, viewModel.Status);
        }

        [Fact]
        public void SelectRobot_ShouldFireEvent()
        {
            IRobotState robot = null;
            viewModel.RobotSelected += (_, e) =>
            {
                robot = e.Robot;
            };

            viewModel.SelectRobot();

            Assert.Equal(robotMock.Object, robot);
        }

    }
}
