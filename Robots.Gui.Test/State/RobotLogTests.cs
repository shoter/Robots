using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robots.Gui.Test.State
{
    public class RobotLogTests
    {
        private IRobotLog robotLog = new RobotLog();

        [Fact]
        public void AddMessage_MessageShouldBeAdded()
        {
            string msg = "Robot has fired a tactical nuclear missile";

            robotLog.AddMessage(msg);

            Assert.Single(robotLog.Entries, msg);
        }

        [Fact]
        public void AddMessage_MessageShouldBeAddedInOrder()
        {
            List<string> messages = new List<string>();

            for(char c = 'a'; c <= 'z'; ++c)
            {
                messages.Add(c.ToString());
                robotLog.AddMessage(c.ToString());
            }

            for(int i = 0;i < messages.Count; ++ i)
            {
                Assert.Equal(messages[i], robotLog.Entries.ElementAt(i));
            }
        }

        [Fact]
        public void Clear_ShouldClearMessages()
        {
            for (int i = 0; i < 123; ++i)
            {
                robotLog.AddMessage("asdasd");
            }

            robotLog.Clear();

            Assert.Empty(robotLog.Entries);
        }
    }
}
