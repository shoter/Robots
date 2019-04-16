using Moq;
using Robots.Core.ProgramExecution;
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
        private readonly Mock<IProgramExecutionService> programExecutionService = new Mock<IProgramExecutionService>();
        private IProgramService programService;

        public ProgramServiceTests()
        {
            programServiceMock = new Mock<ProgramService>(programExecutionService.Object, applicationStateMock.Object);
            programServiceMock.CallBase = true;

            programService = programServiceMock.Object;
            robotMock = applicationStateMock.AddMockRobot();
        }

        [Fact]
        public void CanRemoveProgram_ShouldReturnTrueIfProgramIsNotRunning()
        {
            var program = new Mock<IProgram>().Object;
            programServiceMock.Setup(x => x.GetProgram(program.Id)).Returns(program);

            programExecutionService.Setup(x => x.IsProgramRunning(program)).Returns(false);

            Assert.True(programService.CanRemoveProgram(program.Id));
        }

        [Fact]
        public void CanRemoveProgram_ShouldReturnFalseIfNoProgramIsNotRunning()
        {
            var program = new Mock<IProgram>().Object;
            programServiceMock.Setup(x => x.GetProgram(program.Id)).Returns(program);

            programExecutionService.Setup(x => x.IsProgramRunning(program)).Returns(true);

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
