using Moq;
using Robots.Gui.Modules.Robots.RobotList;
using Robots.Gui.Modules.Robots.RobotSection;
using Robots.Gui.Modules.Robots.RobotView;
using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Robots.RobotSection
{
    public class RobotSectionViewModelTests
    {
        private readonly Mock<IRobotListViewModel> robotListMock = new Mock<IRobotListViewModel>();
        private readonly Mock<IRobotViewViewModel> robotViewMock = new Mock<IRobotViewViewModel>();

        private RobotSectionViewModel viewModel;

        public RobotSectionViewModelTests()
        {
            viewModel = new RobotSectionViewModel(robotListMock.Object, robotViewMock.Object);
        }

        [Fact]
        public void AfterRobotWasSelectedOnList_ViewShouldReceiveINformationAboutThat()
        {
            var robot = new Mock<IRobotState>().Object;

            robotListMock.Raise(x => x.RobotSelected += null, new RobotListItemEventArgs(robot));

            robotViewMock.Verify(x => x.SetRobot(robot), Times.Once);
        }
    }
}
