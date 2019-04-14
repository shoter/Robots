using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Robots.Gui.Helpers
{
    public class UserControlProxy : IUserControlProxy
    {
        public static UserControlProxy NullProxy = new UserControlProxy(null);

        public UserControl UserControl { get; }

        public object DataContext
        {
            get => UserControl.DataContext;
            set => UserControl.DataContext = value;
        }

        public UserControlProxy(UserControl userControl)
        {
            UserControl = userControl;
        }

        public static implicit operator UserControl(UserControlProxy proxy) => proxy.UserControl;

    }

    public static class UserControlProxyExtensions
    {
        public static UserControlProxy AsProxy(this UserControl uc) => new UserControlProxy(uc);
    }
}
