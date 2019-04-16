using Moq;
using Robots.Core.ProgramExecution;
using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Core.Test.UnitTests.ProgramExecution
{
    public class ProgramExecutionServiceTests
    {
        private ProgramExecutionService executionService;

        private readonly Mock<IProgram> programMock = new Mock<IProgram>();

        private readonly Mock<IRobot> robotMock = new Mock<IRobot>();

        private readonly Mock<IProgramExecutor> defaultExecutorMock = new Mock<IProgramExecutor>();

        private readonly Mock<IProgramExecutorFactory> executorFactoryMock = new Mock<IProgramExecutorFactory>();

        public ProgramExecutionServiceTests()
        {
            defaultExecutorMock.SetupGet(x => x.Robot).Returns(robotMock.Object);
            defaultExecutorMock.SetupGet(x => x.Program).Returns(programMock.Object);
            executorFactoryMock.Setup(x => x.Create(It.IsAny<IProgram>(), It.IsAny<IRobot>())).Returns(defaultExecutorMock.Object);
            executionService = new ProgramExecutionService(executorFactoryMock.Object);
        }

        [Fact]
        public void Execute_ShouldReturnProperlyInitializedExecutor()
        {
            var executor = executionService.Execute(programMock.Object, robotMock.Object);

            executorFactoryMock.Verify(x => x.Create(programMock.Object, robotMock.Object), Times.Once);

            Assert.Equal(defaultExecutorMock.Object, executor);
        }
        
        [Fact]
        public void Execute_ShouldThrowIfTryToExecuteTwoProgramsAtSameRobot()
        {
             executionService.Execute(programMock.Object, robotMock.Object);

            Assert.Throws<RobotsException>(() => executionService.Execute(new Mock<IProgram>().Object, robotMock.Object));
        }

        [Fact]
        public void CanExecute_ShouldReturnTrueIfThereIsNoExecutionForRobot()
        {
            Assert.True(executionService.CanExecute(programMock.Object, robotMock.Object));
        }

        [Fact]
        public void CanExecute_ShouldReturnFalseIfRobotIsExecutingSomething()
        {
            executionService.Execute(programMock.Object, robotMock.Object);

            Assert.False(executionService.CanExecute(new Mock<IProgram>().Object, robotMock.Object));
        }

        [Fact]
        public void CanExecute_ShouldReturnTrue_AfterProgramExecutionEnds()
        {
            executionService.Execute(programMock.Object, robotMock.Object);

            defaultExecutorMock.Raise(x => x.ProgramExecutionEnd += null, EventArgs.Empty);

            Assert.True(executionService.CanExecute(new Mock<IProgram>().Object, robotMock.Object));
        }

        [Fact]
        public void IsProgramRunning_ShouldReturnFalse_IfNothingIsRunning()
        {
            Assert.False(executionService.IsProgramRunning(programMock.Object));
        }

        [Fact]
        public void IsProgramRunning_ShouldReturnTrue_IfProgramIsRunning()
        {
            executionService.Execute(programMock.Object, robotMock.Object);

            Assert.True(executionService.IsProgramRunning(programMock.Object));
        }

        [Fact]
        public void ProgramExecutionStarted_ShouldStart_AfterProgramStart()
        {
            IProgram executedProgram = null;
            executionService.ProgramExecutionStarted += (_, e) => executedProgram = e.Program;

            executionService.Execute(programMock.Object, robotMock.Object);

            Assert.Equal(programMock.Object, executedProgram);
        }

        [Fact]
        public void ProgramExecutionCompleted_ShouldNotInvoke_BeforeProgramCompleted()
        {
            IProgram executedProgram = null;
            executionService.ProgramExecutionCompleted += (_, e) => executedProgram = e.Program;

            executionService.Execute(programMock.Object, robotMock.Object);

            Assert.Null(executedProgram);
        }

        [Fact]
        public void ProgramExecutionCompleted_ShouldInvoke_AfterProgramCompleted()
        {
            IProgram executedProgram = null;
            executionService.ProgramExecutionCompleted += (_, e) => executedProgram = e.Program;

            executionService.Execute(programMock.Object, robotMock.Object);

            defaultExecutorMock.Raise(x => x.ProgramExecutionEnd += null, EventArgs.Empty);

            Assert.Equal(programMock.Object, executedProgram);
        }
        
    }
}
