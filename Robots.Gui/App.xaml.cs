using Ninject;
using Robots.Gui.Modules.Notifications;
using Robots.Gui.Modules.Programs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Robots.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            kernel = new RobotsKernel();

            Current.MainWindow = kernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}
