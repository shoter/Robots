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
    public class CommandTurnViewModelTests
    {
        public CommandTurnViewModel ViewModel = new CommandTurnViewModel();

        [Fact]
        public void BackCommand_ChangesStateIntoButtons()
        {
            CommandListState? receivedState = null;
            ViewModel.Transition += (_, e) => receivedState = e.State;

            CommandTurnViewModel.BackCommand.Execute(ViewModel);

            Assert.Equal(CommandListState.Buttons, receivedState);
        }

        [Fact]
        public void AddTurnCommand_WillNotExecute_WithNullAngle()
        {
            ViewModel.Angle = null;

            Assert.False(CommandTurnViewModel.AddTurnCommand.CanExecute(ViewModel));
        }

        [Fact]
        public void AddTurnCommand_WillExecute_WithNonNullAngle()
        {
            var rand = new Random();

            ViewModel.Angle = rand.NextDouble();

            Assert.True(CommandTurnViewModel.AddTurnCommand.CanExecute(ViewModel));
        }

        [Fact]
        public void AddTurnCommand_Execute_CreatesCommandAndChangesState()
        {
            IProgramCommand receivedCommand = null;
            CommandListState? receivedState = null;
            ViewModel.Angle = 123;

            ViewModel.AddProgram += (_, e) => receivedCommand = e.Command;
            ViewModel.Transition += (_, e) => receivedState = e.State;

            CommandTurnViewModel.AddTurnCommand.Execute(ViewModel);

            Assert.Equal(CommandListState.Buttons, receivedState);

            Assert.True(receivedCommand is TurnCommand);
            Assert.Equal(123d, (receivedCommand as TurnCommand).Angle);
        }
        
    }
}
