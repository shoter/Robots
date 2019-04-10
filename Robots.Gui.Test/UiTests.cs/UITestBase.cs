using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robots.Gui.Test.UiTestscs
{
    public class UITestBase
    {
        protected void Start_STA_Thread(ThreadStart whichMethod)
        {
            Thread thread = new Thread(whichMethod);
            thread.SetApartmentState(ApartmentState.STA); 
            thread.Start();
            thread.Join();
        }
    }
}
