using Robots.Core.Programs;
using Robots.Gui.Modules.Programs.AddProgram.CommandList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Programs.AddProgram.CommandList
{
    public class CommandMoveViewModelTests
    {
        public CommandMoveViewModel ViewModel = new CommandMoveViewModel();

        [Fact]
        public void BackCommand_ChangesStateIntoButtons()
        {
            CommandListState? receivedState = null;
            ViewModel.Transition += (_, e) => receivedState = e.State;

            CommandMoveViewModel.BackCommand.Execute(ViewModel);

            Assert.Equal(CommandListState.Buttons, receivedState);
        }

        [Fact]
        public void AddMoveCommand_WillNotExecute_WithNullDistance()
        {
            ViewModel.Distance = null;

            Assert.False(CommandMoveViewModel.AddMoveCommand.CanExecute(ViewModel));
        }

        [Fact]
        public void AddMoveCommand_WillExecute_WithNonNullDistance()
        {
            var rand = new Random();

            ViewModel.Distance = rand.NextDouble();

            Assert.True(CommandMoveViewModel.AddMoveCommand.CanExecute(ViewModel));
        }

        [Fact]
        public void AddMoveCommand_Execute_CreatesCommandAndChangesState()
        {
            IProgramCommand receivedCommand = null;
            CommandListState? receivedState = null;
            ViewModel.Distance = 123;

            ViewModel.AddProgram += (_, e) => receivedCommand = e.Command;
            ViewModel.Transition += (_, e) => receivedState = e.State;

            CommandMoveViewModel.AddMoveCommand.Execute(ViewModel);

            Assert.Equal(CommandListState.Buttons, receivedState);

            Assert.True(receivedCommand is MoveCommand);
            Assert.Equal(123d, (receivedCommand as MoveCommand).Distance);
        }
    }
}
