using Moq;
using Robots.Core.Programs;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Core.Test.UnitTests.Programs
{
    public class ProgramUnitTests
    {
        [Fact]
        public void AddCommand_CommandIsAdded()
        {
            Program program = new Program();
            IProgramCommand command = new Mock<IProgramCommand>().Object;

            program.AddCommand(command);

            Assert.Single(program.Commands, command);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(50)]
        public void AddCommand_CanAddMultipleCommands(int commandCount)
        {
            Program program = new Program();

            List<IProgramCommand> commands = new List<IProgramCommand>();
            for(int i = 0;i < commandCount; ++i)
            {
                var command = new Mock<IProgramCommand>().Object;
                program.AddCommand(command);
                commands.Add(command);
            }

            foreach (var c in commands)
                Assert.Contains(c, program.Commands);
            Assert.Equal(commands.Count(), program.Commands.Count());
        }

        [Fact]
        public void RemoveCommand_CommandCanBeRemoved()
        {
            Program program = new Program();
            IProgramCommand command = new Mock<IProgramCommand>().Object;

            program.AddCommand(command);
            program.RemoveCommand(command);

            Assert.Empty(program.Commands);
        }

        [Fact]
        public void RemoveCommand_ShouldNotChangeOrder()
        {
            Program program = new Program();
            var commandMock = new Mock<IProgramCommand>();

            IProgramCommand[] commands = new IProgramCommand[]
            {
                commandMock.Object,
                commandMock.Object,
                commandMock.Object
            };

            foreach (var c in commands)
                program.AddCommand(c);

            program.RemoveCommand(commands[1]);

            Assert.Equal(commands[0], program.Commands.ElementAt(0));
            Assert.Equal(commands[2], program.Commands.ElementAt(1));
        }

        [Fact]
        public void RemoveCommand_CommandIsRemovedWithMoreCommandsInProgram()
        {
            Program program = new Program();
            IProgramCommand commandToRemove = new Mock<IProgramCommand>().Object;

            for (int i = 0; i < 5; ++i)
                program.AddCommand(new Mock<IProgramCommand>().Object);
            program.AddCommand(commandToRemove);
            for (int i = 0; i < 5; ++i)
                program.AddCommand(new Mock<IProgramCommand>().Object);

            program.RemoveCommand(commandToRemove);

            Assert.Equal(10, program.Commands.Count());
            Assert.DoesNotContain(commandToRemove, program.Commands);
        }

        [Fact]
        public void Start_RobotShouldReceiveCommands()
        {
            Program program = new Program();
            var commandMock = new Mock<IProgramCommand>();
            var robot = new Mock<IRobot>().Object;

            commandMock.Setup(c => c.Execute(robot)).Verifiable();

            for(int i = 0; i < 10; ++i)
            {
                program.AddCommand(commandMock.Object);
            }

            program.Start(robot).RunSynchronously();
        }

        [Fact]
        public void Start_ShouldExecuteAllCommandsInOrder()
        {

        }

        [Fact]
        public void OnCommandExecutionEvents_ShouldBeFiredBeforeAndAfterAllCommandExecution()
        {
            var program = new Program();
            var commandMock = new Mock<IProgramCommand>();
            var robot = new Mock<IRobot>().Object;

            List<IProgramCommand> executedCommands = new List<IProgramCommand>();
            List<IProgramCommand> commands = new List<IProgramCommand>();

            commandMock.Setup(c => c.Execute(robot)).Callback((IProgramCommand c) => executedCommands.Add(c));

            for(int i = 0; i <10;++i)
            {
                var command = commandMock.Object;
                commands.Add(command);
                program.AddCommand(command);
            }

            program.OnCommandExecutionStart += (_, e) => Assert.DoesNotContain(e.Command, executedCommands);
            program.OnCommandExecutionEnd += (_, e) => Assert.Contains(e.Command, executedCommands);

            program.Start(robot);

            foreach(var c in commands)
            {
                Assert.Contains(c, executedCommands);
            }
        }

        [Fact]
        public void OnProgramExecutionEnd_ShouldBeFiredAtEndOfProgram()
        {
            var program = new Program();
            var commandMock = new Mock<IProgramCommand>();
            var robot = new Mock<IRobot>().Object;

            List<IProgramCommand> executedCommands = new List<IProgramCommand>();
            List<IProgramCommand> commands = new List<IProgramCommand>();

            commandMock.Setup(c => c.Execute(robot)).Callback((IProgramCommand c) => executedCommands.Add(c));

            for (int i = 0; i < 10; ++i)
            {
                var command = commandMock.Object;
                commands.Add(command);
                program.AddCommand(command);
            }

            program.OnProgramExecutionEnd += (_, e) =>
            {
                // We must check that all commands were executed before.
                // First we check if executed command count is equal and then we check if each command was executed
                Assert.Equal(commands.Count, executedCommands.Count);

                foreach (var c in commands)
                    Assert.Contains(c, executedCommands);
            };
        }
    }
}