using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Helpers
{
    public interface IUserControlProxy
    {
        object DataContext { get; set; }
    }
}
