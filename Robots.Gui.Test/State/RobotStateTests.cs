using Moq;
using Robots.Core;
using Robots.Core.ProgramExecution;
using Robots.Core.Programs;
using Robots.Gui.State;
using Robots.SDK;
using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.State
{
    public class RobotStateTests
    {
        private IRobotState robotState;

        private Mock<IRobot> robotMock = new Mock<IRobot>();

        private readonly Mock<IProgramExecutionService> executionServiceMock = new Mock<IProgramExecutionService>();

        private readonly Mock<IProgramExecutor> defaultExecutorMock = new Mock<IProgramExecutor>();


        public RobotStateTests()
        {
            executionServiceMock.Setup(x => x.Execute(It.IsAny<IProgram>(), It.IsAny<IRobot>())).Returns(defaultExecutorMock.Object);
            this.robotState = new RobotState(executionServiceMock.Object, robotMock.Object, new Mock<IRobotLog>().Object);
        }

        [Fact]
        public void Constructor_ProperValues()
        {
            Assert.False(robotState.IsProgramRunning);
            Assert.Null(robotState.AssignedProgram);
        }

        [Fact]
        public void AssignProgram_ShouldAssignProgram()
        {
            var program = new Mock<IProgram>().Object;

            robotState.AssignProgram(program);
            Assert.Equal(program, robotState.AssignedProgram);
        }

        [Fact]
        public void RunProgram_ShouldStartAssignedProgram()
        {
            var programMock = new Mock<IProgram>();
            IProgram program = programMock.Object;

            robotState.AssignProgram(program);
            robotState.RunProgram();

            Assert.True(robotState.IsProgramRunning);
        }

        [Fact]
        public void RunProgram_ShouldNotRunTwoPrograms()
        {
            var program = new Mock<IProgram>().Object;

            robotState.AssignProgram(program);
            robotState.RunProgram();
            Assert.Throws<RobotsException>(() => robotState.RunProgram());
        }

        [Fact]
        public void RunProgram_CannotAssignProgramAfterRunningProgram()
        {
            var program = new Mock<IProgram>().Object;

            robotState.AssignProgram(program);
            robotState.RunProgram();
            Assert.Throws<RobotsException>(() => robotState.AssignProgram(program));
        }

        [Fact]
        public void RunProgram_AfterExecutionEnds_IsProgramRunningSetToFalse()
        {
            var programMock = new Mock<IProgram>();
            var program = programMock.Object; 

            robotState.AssignProgram(program);
            robotState.RunProgram();



            defaultExecutorMock.Raise(x => x.ProgramExecutionEnd += null, EventArgs.Empty);

            Assert.False(robotState.IsProgramRunning);
        }

        [Fact]
        public void Status_ShouldReturnIdle_IfNoProgramIsRunning()
        {
            Assert.Equal("Idle", robotState.Status);
        }

        [Fact]
        public void Status_ShouldHaveProgramName_WhenProgramIsRunning()
        {
            var programMock = new Mock<IProgram>();
            programMock.SetupGet(x => x.Name).Returns("asdasdasdasd");
            var program = programMock.Object;

            robotState.AssignProgram(program);
            robotState.RunProgram();

            Assert.Contains(programMock.Object.Name, robotState.Status);
        }
    }
}
