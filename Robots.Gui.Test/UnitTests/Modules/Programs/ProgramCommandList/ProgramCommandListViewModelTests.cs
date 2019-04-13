using Moq;
using Robots.Core.Programs;
using Robots.Gui.Modules.Programs.ProgramCommandList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Programs.ProgramCommandList
{
    public class ProgramCommandListViewModelTests
    {
        private readonly Mock<IProgram> programMock = new Mock<IProgram>();

        private ProgramCommandListViewModel viewModel;

        public ProgramCommandListViewModelTests()
        {
            this.viewModel = new ProgramCommandListViewModel();
            this.viewModel.SetProgram(programMock.Object);
        }

        [Fact]
        public void SetProgram_HasProgramCommands()
        {
            programMock.SetupGet(x => x.Commands)
            .Returns(new IProgramCommand[]
            {
                createProgramCommandMock(),
                createProgramCommandMock(),
                createProgramCommandMock()
            });

            var cmds = programMock.Object.Commands;

            this.viewModel.SetProgram(programMock.Object);

            foreach (var c in cmds)
            {
                Assert.Contains(viewModel.Commands, cvm => cvm.DisplayName == c.Describe());
            }
        }

        [Fact]
        public void SetProgram_ShouldHaveNewCommands()
        {
            programMock.SetupGet(x => x.Commands)
            .Returns(new IProgramCommand[]
            {
                createProgramCommandMock(),
                createProgramCommandMock(),
                createProgramCommandMock()
            });

            var newProgram = new Mock<IProgram>();
            newProgram.SetupGet(x => x.Commands)
                .Returns(new IProgramCommand[]
                {
                    createProgramCommandMock()
                });

            viewModel.SetProgram(newProgram.Object);

            var cmds = newProgram.Object.Commands;

            foreach (var c in cmds)
            {
                Assert.Contains(viewModel.Commands, cvm => cvm.DisplayName == c.Describe());
            }
        }

        [Fact]
        public void AddCommand_AddsCommand()
        {
            var commandMock = new Mock<IProgramCommand>();
            commandMock.Setup(x => x.Describe()).Returns("asdasdsadsda");
            var command = commandMock.Object;

            viewModel.AddCommand(command);

            Assert.Single(viewModel.Commands, c => c.DisplayName == command.Describe());
        }

        private ulong createdMocks = 0;
        private IProgramCommand createProgramCommandMock()
        {
            var mock = new Mock<IProgramCommand>();
            mock.Setup(x => x.Describe()).Returns(createdMocks.ToString());

            createdMocks++;

            return mock.Object;
        }
    }
}
