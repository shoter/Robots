using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Gui.Modules.Robots.RobotLog
{
    public class RobotLogViewModel : IRobotLogViewModel
    {
        private ObservableCollection<IRobotLogEntryViewModel> entryCollection = new ObservableCollection<IRobotLogEntryViewModel>();

        /// <summary>
        /// IEnumerable to not make it editable outside
        /// </summary>
        public IEnumerable<IRobotLogEntryViewModel> Entries => entryCollection;

        public void AddEntry(IRobotLogEntryViewModel entry)
        {
            entryCollection.Add(entry);
        }

        public void Clear()
        {
            entryCollection.Clear();
        }
    }
}
