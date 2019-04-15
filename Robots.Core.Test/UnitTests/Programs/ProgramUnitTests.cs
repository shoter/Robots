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
                new Mock<IProgramCommand>().Object,
                new Mock<IProgramCommand>().Object,
                new Mock<IProgramCommand>().Object
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
    }
}