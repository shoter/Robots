using Robots.Gui.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui
{
    public interface IMainWindowControlFactory
    {
        /// <summary>
        /// Should create User control (proxy) for given main window state. The user control should already have data context bindded
        /// </summary>
        /// <returns>User control inside proxy</returns>
        IUserControlProxy Create(MainWindowState state);
    }
}
