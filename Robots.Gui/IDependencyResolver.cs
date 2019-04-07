using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui
{
    public interface IDependencyResolver
    {
        T Get<T>(params IParameter[] parameters);
    }
}
