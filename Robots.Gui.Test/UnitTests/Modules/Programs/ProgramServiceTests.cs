using Moq;
using Robots.Core.Programs;
using Robots.Gui.Modules.Programs;
using Robots.Gui.State;
using Robots.Gui.Test.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Programs
{
    public class ProgramServiceTests
    {
        private readonly ApplicationStateMock applicationStateMock = new ApplicationStateMock();

        private readonly Mock<IRobotState> robotMock;


        private readonly Mock<ProgramService> programServiceMock;
        private IProgramService programService;

        public ProgramServiceTests()
        {
            programServiceMock = new Mock<ProgramService>(applicationStateMock.Object);
            programServiceMock.CallBase = true;

            programService = programServiceMock.Object;
            robotMock = applicationStateMock.AddMockRobot();
        }

        [Fact]
        public void GetRobotsRunningProgram_ShouldReturnRobotsRunningGivenProgram()
        {
            var programMock = new Mock<IProgram>();
            programMock.SetupGet(x => x.Id).Returns(123);

            var program = programMock.Object;

            var robotWithGivenProgramRunningMock = new Mock<IRobotState>();
            var robotWithGivenProgramNotRunningMock = new Mock<IRobotState>();
            var robotWithOtherProgramRunningMock = new Mock<IRobotState>();
            var robotWithOtherProgramNotRunningMock = new Mock<IRobotState>();

            robotWithGivenProgramRunningMock.SetupGet(x => x.AssignedProgram).Returns(program);
            robotWithGivenProgramRunningMock.SetupGet(x => x.IsProgramRunning).Returns(true);

            robotWithGivenProgramNotRunningMock.SetupGet(x => x.AssignedProgram).Returns(program);

            robotWithOtherProgramRunningMock.SetupGet(x => x.AssignedProgram).Returns(new Mock<IProgram>().Object);
            robotWithOtherProgramRunningMock.SetupGet(x => x.IsProgramRunning).Returns(true);

            robotWithOtherProgramNotRunningMock.SetupGet(x => x.AssignedProgram).Returns(new Mock<IProgram>().Object);

            List<IRobotState> robots = new List<IRobotState>()
            {
                robotWithGivenProgramRunningMock.Object,
                robotWithGivenProgramNotRunningMock.Object,
                robotWithOtherProgramNotRunningMock.Object,
                robotWithOtherProgramRunningMock.Object
            };

            applicationStateMock.SetupGet(x => x.Robots).Returns(robots);

            var returnedRobots = programService.GetRobotsRunningProgram(program.Id);

            Assert.Same(returnedRobots.First(), robotWithGivenProgramRunningMock.Object);
            Assert.Single(returnedRobots);
        }

        [Fact]
        public void CanRemoveProgram_ShouldReturnTrueIfNoRobotsAreUsingProgram()
        {
            var program = new Mock<IProgram>().Object;
            programServiceMock.Setup(x => x.GetRobotsRunningProgram(program.Id)).Returns(new List<IRobotState>());

            Assert.True(programService.CanRemoveProgram(program.Id));
        }

        [Fact]
        public void CanRemoveProgram_ShouldReturnFalseIfSomeRobotsAreUsingProgram()
        {
            var program = new Mock<IProgram>().Object;
            programServiceMock.Setup(x => x.GetRobotsRunningProgram(program.Id)).Returns(new List<IRobotState>() { robotMock.Object });

            Assert.False(programService.CanRemoveProgram(program.Id));
        }

        [Fact]
        public void RemoveProgram_ShouldDeassignRobotsWithGivenProgram()
        {
            var program = new Mock<IProgram>().Object;
            robotMock.SetupGet(x => x.IsProgramRunning).Returns(true);
            robotMock.SetupGet(x => x.AssignedProgram).Returns(program);
            programServiceMock.Setup(x => x.CanRemoveProgram(It.IsAny<ulong>())).Returns(true);

            programService.RemoveProgram(program.Id);

            robotMock.Verify(x => x.DeassignProgram(), Times.Once);
        }

        [Fact]
        public void RemoveProgram_ShouldRemoveProgramFromState()
        {
            var program = new Mock<IProgram>().Object;
            programServiceMock.Setup(x => x.CanRemoveProgram(It.IsAny<ulong>())).Returns(true);
            applicationStateMock.Setup(x => x.GetProgram(program.Id)).Returns(program);
            

            programService.RemoveProgram(program.Id);

            applicationStateMock.Verify(x => x.RemoveProgram(program), Times.Once);
        }

        [Fact]
        public void RemoveProgram_ShouldNotRemoveProgramFromRobotsWithDifferentProgram()
        {
            var program = new Mock<IProgram>().Object;
            robotMock.SetupGet(x => x.IsProgramRunning).Returns(true);
            robotMock.SetupGet(x => x.AssignedProgram).Returns(program);
            programServiceMock.Setup(x => x.CanRemoveProgram(It.IsAny<ulong>())).Returns(true);

            programService.RemoveProgram(program.Id + 1); //always different ID than program.

            robotMock.Verify(x => x.DeassignProgram(), Times.Never);
        }
    }
}
