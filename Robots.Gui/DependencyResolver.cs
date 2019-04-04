using Ninject;
using Ninject.Parameters;
using Robots.Gui.Modules.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui
{
    public class DependencyResolver
    {
        private static readonly IKernel kernel;

        static DependencyResolver()
        {
            kernel = new StandardKernel(
                new MainModule(),
                new ProgramModule()
                );
        }

        public static T Get<T>(params IParameter[] parameters)
        {
            return kernel.Get<T>(parameters);
        }
    }
}
