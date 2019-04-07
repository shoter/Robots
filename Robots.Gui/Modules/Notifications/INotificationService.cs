using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Notifications
{
    public interface INotificationService
    {
        void ShowWarningMessageBox(string message);
    }
}
