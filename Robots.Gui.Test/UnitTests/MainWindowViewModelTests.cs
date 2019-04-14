using Moq;
using Robots.Gui.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.UnitTests
{
    public class MainWindowViewModelTests
    {
        private readonly Mock<IMainWindowControlFactory> controlFactoryMock = new Mock<IMainWindowControlFactory>();
        private readonly IUserControlProxy defaultProxy = new Mock<IUserControlProxy>().Object;

        private MainWindowViewModel viewModel;

        public MainWindowViewModelTests()
        {
            controlFactoryMock.Setup(x => x.Create(It.IsAny<MainWindowState>())).Returns(defaultProxy);

            viewModel = new MainWindowViewModel(controlFactoryMock.Object);
        }

        [Fact]
        public void AfterConstructor_ShouldHaveProperValues()
        {
            Assert.Equal(MainWindowState.None, viewModel.State);
            Assert.Equal(defaultProxy, viewModel.CurrentControl);
            controlFactoryMock.Verify(x => x.Create(MainWindowState.None), Times.Once);
        }

        [Fact]
        public void ShouldCreateNewControl_AfterStateChange()
        {
            var control = new Mock<IUserControlProxy>().Object;

            controlFactoryMock.Setup(x => x.Create(MainWindowState.Robots)).Returns(control);

            viewModel.State = MainWindowState.Robots;

            Assert.Equal(MainWindowState.Robots, viewModel.State);
            Assert.Equal(control, viewModel.CurrentControl);
            controlFactoryMock.Verify(x => x.Create(MainWindowState.Robots), Times.Once);
        }
    }
}
