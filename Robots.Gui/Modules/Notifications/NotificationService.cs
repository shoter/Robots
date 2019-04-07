using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Robots.Gui.Modules.Notifications
{
    public class NotificationService : INotificationService
    {
        public void ShowWarningMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}
