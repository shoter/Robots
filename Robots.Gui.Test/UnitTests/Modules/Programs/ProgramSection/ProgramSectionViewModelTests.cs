using Moq;
using Robots.Core.Programs;
using Robots.Gui.Modules.Programs;
using Robots.Gui.Modules.Programs.ProgramList;
using Robots.Gui.Modules.Programs.ProgramsSection;
using Robots.Gui.Modules.Programs.ProgramView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests.Modules.Programs.ProgramSection
{
    public class ProgramSectionViewModelTests
    {
        private readonly Mock<IProgramListViewModel> programListMock = new Mock<IProgramListViewModel>();
        private readonly Mock<IProgramViewViewModel> programViewMock = new Mock<IProgramViewViewModel>();
        private readonly Mock<IProgramService> programServiceMock = new Mock<IProgramService>();

        private ProgramSectionViewModel viewModel;

        public ProgramSectionViewModelTests()
        {
            viewModel = new ProgramSectionViewModel(programListMock.Object, programViewMock.Object, programServiceMock.Object);
        }

        [Fact]
        public void OnProgramSelect_ProgramShouldBeSelected()
        {
            const ulong programId = 1234;
            var programMock = new Mock<IProgram>();
            programMock.SetupGet(x => x.Id).Returns(programId);
            var args = new ProgramListItemEventArgs(new ProgramListItemViewModel(programMock.Object));

            programServiceMock.Setup(x => x.GetProgram(programId)).Returns(programMock.Object);

            programListMock.Raise(x => x.ProgramSelect += null, args);
            programViewMock.Verify(x => x.SetProgram(programMock.Object), Times.Once);
        }

        [Fact]
        public void OnProgramRemove_ProgramShouldBeSetToNull()
        {
            const ulong programId = 1234;
            var programMock = new Mock<IProgram>();
            programMock.SetupGet(x => x.Id).Returns(programId);
            var args = new ProgramListItemEventArgs(new ProgramListItemViewModel(programMock.Object));

            programServiceMock.Setup(x => x.GetProgram(programId)).Returns(programMock.Object);

            programListMock.Raise(x => x.ProgramSelect += null, args);
            programListMock.Raise(x => x.ProgramRemove += null, args);

            programViewMock.Verify(x => x.SetProgram(null), Times.Once);

        }

    }
       
}
