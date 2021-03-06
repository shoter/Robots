﻿using Moq;
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

        private Mock<IProgram> programMock = new Mock<IProgram>();

        private readonly Mock<IProgramExecutionService> executionServiceMock = new Mock<IProgramExecutionService>();

        private readonly Mock<IProgramExecutor> defaultExecutorMock = new Mock<IProgramExecutor>();


        public RobotStateTests()
        {
            executionServiceMock.Setup(x => x.Execute(programMock.Object, robotMock.Object)).Returns(defaultExecutorMock.Object);
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
            var program = programMock.Object;

            robotState.AssignProgram(program);
            Assert.Equal(program, robotState.AssignedProgram);
        }

        [Fact]
        public void RunProgram_ShouldStartAssignedProgram()
        {
            IProgram program = programMock.Object;

            robotState.AssignProgram(program);
            robotState.RunProgram();

            Assert.True(robotState.IsProgramRunning);
        }

        [Fact]
        public void RunProgram_ShouldNotRunTwoPrograms()
        {
            var program = programMock.Object; 

            robotState.AssignProgram(program);
            robotState.RunProgram();
            Assert.Throws<RobotsException>(() => robotState.RunProgram());
        }

        [Fact]
        public void RunProgram_CannotAssignProgramAfterRunningProgram()
        {
            var program = programMock.Object;

            robotState.AssignProgram(program);
            robotState.RunProgram();
            Assert.Throws<RobotsException>(() => robotState.AssignProgram(program));
        }

        [Fact]
        public void RunProgram_WillExecuteProgram()
        {
            var program = programMock.Object;

            robotState.AssignProgram(program);
            robotState.RunProgram();

            executionServiceMock.Verify(x => x.Execute(program, robotMock.Object), Times.Once);
        }

        [Fact]
        public void RunProgram_AfterExecutionEnds_IsProgramRunningSetToFalse()
        {
            var program = programMock.Object; 

            robotState.AssignProgram(program);
            robotState.RunProgram();

            defaultExecutorMock.SetupGet(x => x.IsCompleted).Returns(true);

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
            programMock.SetupGet(x => x.Name).Returns("asdasdasdasd");
            var program = programMock.Object;

            robotState.AssignProgram(program);
            robotState.RunProgram();

            Assert.Contains(programMock.Object.Name, robotState.Status);
        }
    }
}
