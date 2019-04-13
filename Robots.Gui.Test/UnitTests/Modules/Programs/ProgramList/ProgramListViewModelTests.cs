using Moq;
using Robots.Core.Programs;
using Robots.Gui.Modules.Notifications;
using Robots.Gui.Modules.Programs;
using Robots.Gui.Modules.Programs.ProgramList;
using Robots.Gui.Test.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Programs.ProgramList
{
    public class ProgramListViewModelTests
    {
        ApplicationStateMock stateMock = new ApplicationStateMock();

        private readonly List<IProgram> programs = new List<IProgram>();

        private readonly Mock<IProgramService> programServiceMock = new Mock<IProgramService>();
        private readonly Mock<IProgramFactory> programFactory = new Mock<IProgramFactory>();
        private readonly INotificationService notificationService = new Mock<INotificationService>().Object;

        private ProgramListViewModel viewModel;

        public ProgramListViewModelTests()
        {
            for(int i = 0; i < 5; ++i)
            {
                var mock = new Mock<IProgram>();
                mock.SetupGet(x => x.Id).Returns((ulong)i);
                programs.Add(mock.Object);
            }

            stateMock.SetupGet(x => x.Programs).Returns(programs);

            viewModel = new ProgramListViewModel(stateMock.Object, programServiceMock.Object, programFactory.Object, notificationService);
        }

        [Fact]
        public void AfterConstructor_ProgramsShouldBeTakenFromState()
        {
            foreach(var p in programs)
            {
                // order is not important.
                Assert.Contains(viewModel.Programs, ivm => ivm.Id == p.Id);
            }
        }
    }
}
