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
            this.viewModel = new ProgramCommandListViewModel(programMock.Object);
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
    }
}
