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
        private readonly INotificationService notificationService = new Mock<INotificationService>().Object;

        public ProgramListViewModelTests()
        {
            for(int i = 0; i < 5; ++i)
            {
                var mock = new Mock<IProgram>();
                mock.SetupGet(x => x.Id).Returns((ulong)i);
                programs.Add(mock.Object);
            }

            stateMock.SetupGet(x => x.Programs).Returns(programs);
        }

        [Fact]
        public void AfterConstructor_ProgramsShouldBeTakenFromState()
        {
            var vm = new ProgramListViewModel(stateMock.Object, programServiceMock.Object, notificationService);

            foreach(var p in programs)
            {
                // order is not important.
                Assert.Contains(vm.Programs, ivm => ivm.Id == p.Id);
            }
        }

        [Fact]
        public void OnTriggeringItemRemovalOnChild_ShouldRemoveProgramIfItCan()
        {
            var vm = new ProgramListViewModel(stateMock.Object, programServiceMock.Object, notificationService);
            var program = vm.Programs.First();
            programServiceMock.Setup(x => x.CanRemoveProgram(program.Id)).Returns(true);

            program.RemoveProgram.Execute(program);

            programServiceMock.Verify(x => x.RemoveProgram(program.Id), Times.Once);
        }

        [Fact]
        public void OnTriggeringItemRemovalOnChild_ShouldNotRemoveProgramIfItCannot()
        {
            var vm = new ProgramListViewModel(stateMock.Object, programServiceMock.Object, notificationService);
            var program = vm.Programs.First();
            programServiceMock.Setup(x => x.CanRemoveProgram(program.Id)).Returns(false);

            program.RemoveProgram.Execute(program);

            programServiceMock.Verify(x => x.RemoveProgram(program.Id), Times.Never);

            // I am not testing if notification service displayed any warning
            // It's implementation detail and for me is not required feature for the method to run.
        }
    }
}
