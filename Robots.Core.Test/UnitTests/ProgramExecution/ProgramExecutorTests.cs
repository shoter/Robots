using Moq;
using Robots.Core.ProgramExecution;
using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Core.Test.UnitTests.ProgramExecution
{
    public class ProgramExecutorTests
    {
        private readonly Mock<IProgram> programMock = new Mock<IProgram>();
        private readonly Mock<IRobot> robotMock = new Mock<IRobot>();


        public ProgramExecutorTests()
        {

        }

        [Fact]
        public void ShouldExecuteAllTasksInOrder()
        {
            var commands = new Mock<IProgramCommand>[]
            {
                new Mock<IProgramCommand>(),
                new Mock<IProgramCommand>(),
                new Mock<IProgramCommand>()
            };

            int j = 0;
            for (int i = 0; i < commands.Length; ++i)
            {
                // I cannot reference 'i' inside Callback because it will have always value 3 inside callback.
                // It's always referencing the same thing inside callback. meh
                // I need to create local variable - oh gosh.
                int a = i;
                commands[i].Setup(x => x.Execute(robotMock.Object)).Callback(() => Assert.Equal(j++, a));
            }

            programMock.SetupGet(x => x.Commands).Returns(commands.Select(x => x.Object));

            var exec = new ProgramExecutor(programMock.Object, robotMock.Object);
            exec.Start();

            Thread.Sleep(1000);

            Assert.True(exec.IsCompleted);
        }

        [Fact]
        public void CannotStartSameExecutorTwice()
        {
            var commands = new Mock<IProgramCommand>[]
               {
                new Mock<IProgramCommand>(),
                new Mock<IProgramCommand>(),
                new Mock<IProgramCommand>()
               };

            programMock.SetupGet(x => x.Commands).Returns(commands.Select(x => x.Object));

            var exec = new ProgramExecutor(programMock.Object, robotMock.Object);

            exec.Start();

            Assert.Throws<RobotsException>(() => exec.Start());
        }

        [Fact]
        public void ShouldTriggerProperEvents()
        {
            var commands = new Mock<IProgramCommand>[]
                {
                new Mock<IProgramCommand>(),
                new Mock<IProgramCommand>(),
                new Mock<IProgramCommand>()
                };

            int j = 0;
            for (int i = 0; i < commands.Length; ++i)
            {
                commands[i].Setup(x => x.Execute(robotMock.Object)).Callback(() => ++j);
            }

            programMock.SetupGet(x => x.Commands).Returns(commands.Select(x => x.Object));

            var exec = new ProgramExecutor(programMock.Object, robotMock.Object);

            exec.CommandExecutionStart += (_, e) => Assert.Equal(commands[j].Object, e.Command);
            exec.CommandExecutionEnd += (_, e) => Assert.Equal(commands[j - 1].Object, e.Command);
            exec.ProgramExecutionEnd += (_, e) => Assert.Equal(commands.Length, j);


        }
    }
}
