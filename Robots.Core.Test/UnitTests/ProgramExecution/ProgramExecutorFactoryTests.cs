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
    public class ProgramExecutorFactoryTests
    {
        private readonly ProgramExecutorFactory factory = new ProgramExecutorFactory();

        [Fact]
        public void Create_ShouldCreateProperExecutor()
        {
            var programMock = new Mock<IProgram>();
            var robotMock = new Mock<IRobot>();
            IProgramExecutor executor = factory.Create(programMock.Object, robotMock.Object);

            Assert.Equal(programMock.Object, executor.Program);
            Assert.Equal(robotMock.Object, executor.Robot);
            Assert.False(executor.IsCompleted);
        }
    }
}
