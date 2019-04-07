using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Notifications
{
    public class NotificationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INotificationService>().To<NotificationService>();
        }
    }
}
