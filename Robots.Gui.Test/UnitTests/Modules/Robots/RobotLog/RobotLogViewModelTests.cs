using Moq;
using Robots.Gui.Modules.Robots.RobotLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Robots.RobotLog
{
    public class RobotLogViewModelTests
    {
        private RobotLogViewModel viewModel;

        public RobotLogViewModelTests()
        {
            viewModel = new RobotLogViewModel();
        }

        [Fact]
        public void AfterConstructor_NoEntriesInLog()
        {
            Assert.Empty(viewModel.Entries);
        }

        [Fact]
        public void AddEntry_ShouldAddEntry()
        {
            var entry = new Mock<IRobotLogEntryViewModel>().Object;

            viewModel.AddEntry(entry);

            Assert.Single(viewModel.Entries, entry);
        }

        [Fact]
        public void Clear_ClearsAllObjectsInLog()
        {
            for (int i = 0; i < 123; ++i)
                viewModel.AddEntry(new Mock<IRobotLogEntryViewModel>().Object);

            viewModel.Clear();

            Assert.Empty(viewModel.Entries);
        }
    }
}
