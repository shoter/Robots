using Moq;
using Robots.Core.Programs;
using Robots.Gui.Modules.Notifications;
using Robots.Gui.Modules.Programs;
using Robots.Gui.Modules.Programs.ProgramList;
using Robots.Gui.Test.State;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace Robots.Gui.Test.UiTestscs.Modules.Programs
{
    public class ProgramListControlTests : UITestBase
    {
        ApplicationStateMock applicationStateMock = new ApplicationStateMock();
        Mock<IProgramService> programServiceMock = new Mock<IProgramService>();
        INotificationService notificationService = new Mock<INotificationService>().Object;

        [Fact]
        public void ProgramList_ShouldDisplayNameOfPrograms()
        {
            /*var applicationPath = Path.Combine(typeof(Robots.Gui.App).Assembly.CodeBase);

            if(applicationPath.StartsWith("file:///"))
            {
                applicationPath = applicationPath.Substring("file:///".Length);
            }

            Application application = Application.Launch(applicationPath);
            Window window = application.GetWindow("MainWindow", InitializeOption.NoCache);*/


            /*var programs = new List<IProgram>();

            for (int i = 0; i < 5; ++i)
            {
                var mock = new Mock<IProgram>();
                mock.SetupGet(x => x.Id).Returns((ulong)i);
                mock.SetupGet(x => x.Name).Returns(i.ToString());

                programs.Add(mock.Object);
            }

            var workPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var workConfiguration = new WorkConfiguration
            {
                ArchiveLocation = workPath,
                Name = "WpfTodo"
            };

            var vm = new ProgramListViewModel(applicationStateMock.Object, programServiceMock.Object, notificationService);

            using (var session = new WorkSession())*/

        }
    }
}
