using Moq;
using Robots.Common;
using Robots.Gui.State;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Test.State
{
    public class ApplicationStateMock : Mock<IApplicationState>
    {
        public List<IRobotState> Robots { get; } = new List<IRobotState>();

        public ApplicationStateMock()
        {
            SetupGet(x => x.Robots).Returns(Robots);
        }

        public Mock<IRobotState> AddMockRobot()
        {
            var mock = new Mock<IRobotState>();
            mock.SetupGet(x => x.Id).Returns(UniqueIdGenerator.Global.Id);
            Robots.Add(mock.Object);

            return mock;
        }

    }
}
