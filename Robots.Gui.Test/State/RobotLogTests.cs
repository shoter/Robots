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
            var entry = new RobotLogEntry("Robot has fired a tactical nuclear missile");

            robotLog.AddEntry(entry);

            Assert.Single(robotLog.Entries, entry);
        }

        [Fact]
        public void AddMessage_MessageShouldBeAddedInOrder()
        {
            List<RobotLogEntry> entries = new List<RobotLogEntry>();

            for(char c = 'a'; c <= 'z'; ++c)
            {
                var entry = new RobotLogEntry(c.ToString());
                entries.Add(entry);
                robotLog.AddEntry(entry);
            }

            for(int i = 0;i < entries.Count; ++ i)
            {
                Assert.Equal(entries[i], robotLog.Entries.ElementAt(i));
            }
        }

        [Fact]
        public void Clear_ShouldClearMessages()
        {
            for (int i = 0; i < 123; ++i)
            {
                robotLog.AddEntry(new RobotLogEntry("asdasd"));
            }

            robotLog.Clear();

            Assert.Empty(robotLog.Entries);
        }
    }
}
