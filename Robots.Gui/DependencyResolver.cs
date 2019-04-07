using Ninject;
using Ninject.Parameters;
using Robots.Gui.Modules.Notifications;
using Robots.Gui.Modules.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public static IDependencyResolver Current { get; }

        public DependencyResolver()
        {
            kernel = new StandardKernel(
                new MainModule(),
                new ProgramModule(),
                new NotificationModule()
                );
        }

        public T Get<T>(params IParameter[] parameters)
        {
            return kernel.Get<T>(parameters);
        }


    }
}
