using Moq;
using Robots.Gui.Modules.Robots.RobotLog;
using Robots.Gui.Modules.Robots.RobotView;
using Robots.Gui.State;
using Robots.Gui.Test.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Robots.RobotView
{
    public class RobotViewViewModelTests
    {
        private readonly ApplicationStateMock state = new ApplicationStateMock();

        private readonly Mock<IRobotLogViewModel> robotLogMock = new Mock<IRobotLogViewModel>();

        private IRobotViewViewModel viewModel;

        public RobotViewViewModelTests()
        {
            viewModel = new RobotViewViewModel(state, robotLogMock.Object);
        }

    }
}
