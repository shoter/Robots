using Moq;
using Robots.Core.Programs;
using Robots.Gui.Helpers;
using Robots.Gui.Modules.Programs.AddProgram;
using Robots.Gui.Modules.Programs.AddProgram.CommandList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Programs.AddProgram
{
    public class AddProgramViewModelTests
    {
        private readonly Mock<ICommandListFactory> commandListFactoryMock = new Mock<ICommandListFactory>();

        private readonly CommandListTestViewModel commandListTestVM = new CommandListTestViewModel();

        private AddProgramViewModel viewModel;

        public AddProgramViewModelTests()
        {
            commandListFactoryMock.Setup(x => x.CreateViewModel(It.IsAny<CommandListState>()))
             .Returns(commandListTestVM);

            commandListFactoryMock.Setup(x => x.CreateControl(It.IsAny<CommandListState>()))
                .Returns(new Mock<IUserControlProxy>().Object);

            viewModel = new AddProgramViewModel(commandListFactoryMock.Object);
        }

        [WpfFact]
        public void AfterConstructor_CommandViewModelAndControlAreCreated_AndProperStateIsSet()
        {
            Assert.Equal(CommandListState.Buttons, viewModel.CommandState);
            Assert.NotNull(viewModel.CommandAddViewModel);
            Assert.NotNull(viewModel.CommandAddControl);
        }

        [Fact]
        public void AddCommand_ShouldBeInvoked_IfCreatedViewModelWillRequestThat()
        {
            IProgramCommand receivedCommand = null;
            IProgramCommand commandToReceive = new Mock<IProgramCommand>().Object;

            viewModel.AddCommand += (_, e) => receivedCommand = e.Command;

            commandListTestVM.AddCommandInvoke(commandToReceive);

            Assert.Equal(commandToReceive, receivedCommand);
        }

        [Fact]
        public void State_ShouldBeChanged_IfCreatedViewModelWillRequestThat()
        {
            IUserControlProxy newUserControl = new Mock<IUserControlProxy>().Object;
            CommandListTestViewModel newVm = new CommandListTestViewModel();

            commandListFactoryMock.Setup(x => x.CreateViewModel(It.IsAny<CommandListState>()))
                .Returns(newVm);

            commandListFactoryMock.Setup(x => x.CreateControl(It.IsAny<CommandListState>()))
                .Returns(newUserControl);

            commandListTestVM.TransitionInvoke(CommandListState.Move);



            Assert.Equal(CommandListState.Move, viewModel.CommandState);
            Assert.Equal(newUserControl, viewModel.CommandAddControl);
            Assert.Equal(newVm, viewModel.CommandAddViewModel);
        }

        private class CommandListTestViewModel : CommandListBaseViewModel
        {
            public virtual new void AddCommandInvoke(IProgramCommand c) => base.AddCommandInvoke(c);

            public virtual new void TransitionInvoke(CommandListState s) => base.TransitionInvoke(s);
        }
    }
}
