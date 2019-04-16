using Robots.Common;
using Robots.Gui.Modules.Programs.AddProgram.CommandList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Programs.AddProgram.CommandList
{
    public class CommandListFactoryTests
    {
        private readonly ICommandListFactory commandListFactory = new CommandListFactory();

        [WpfFact] // we need STA thread and WpfFact runs on StaThread
        public void CreateControl_ShouldBeAbleToCreateControlsForAllStates()
        {
            foreach(var state in Enums.ToList<CommandListState>())
            {
                // this is just a smoke test.
                commandListFactory.CreateControl(state);
            }
        }

        [Fact]
        public void CreateViewModel_ShouldBeAbleToCreateControlsForAllStates()
        {
            foreach (var state in Enums.ToList<CommandListState>())
            {
                // this is just a smoke test.
                commandListFactory.CreateViewModel(state);
            }
        }
    }
}
