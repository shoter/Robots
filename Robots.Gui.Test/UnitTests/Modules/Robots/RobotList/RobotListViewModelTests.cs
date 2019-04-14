using Robots.Gui.Modules.Robots.RobotList;
using Robots.Gui.State;
using Robots.Gui.Test.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Robots.RobotList
{
    public class RobotListViewModelTests
    {
        private ApplicationStateMock stateMock = new ApplicationStateMock();

        private RobotListViewModel viewModel;

        public RobotListViewModelTests()
        {
            viewModel = new RobotListViewModel(stateMock.Object);
        }

        [Fact]
        public void AfterConstructor_ShouldHaveRobotsFromState()
        {
            foreach(var robot in stateMock.Object.Robots)
            {
                Assert.Contains(viewModel.Robots, r => r.Id == robot.Id);
            }
        }
    }
}
