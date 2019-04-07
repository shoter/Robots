using Moq;
using Robots.Core.Programs;
using Robots.Gui.Modules.Programs.ProgramList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Programs.ProgramList
{
    public class ProgramListItemViewModelTests
    {
        [Fact]
        public void AfterConstructor_PropertiesProperlySet()
        {
            var programMock = new Mock<IProgram>();
            string name = "some name";
            ulong id = 1234;

            programMock.SetupGet(x => x.Name).Returns(name);
            programMock.SetupGet(x => x.Id).Returns(id);

            var itemVm = new ProgramListItemViewModel(programMock.Object);

            Assert.Equal(name, itemVm.Name);
            Assert.Equal(id, itemVm.Id);
        }

        [Fact]
        public void RemoveCommand_ShouldInvokeOnProgramRemoval()
        {
            var itemVm = new ProgramListItemViewModel(new Mock<IProgram>().Object);

            itemVm.OnProgramRemoval += (sender, e) =>
            {
                Assert.Equal(sender, itemVm);
                Assert.Equal(e.Item, itemVm);
            };

            itemVm.RemoveProgram.Execute(itemVm);
        }
    }
}
