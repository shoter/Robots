using Robots.Gui.State;
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

        public RobotLogViewModel() { }

        /// <summary>
        /// IEnumerable to not make it editable outside
        /// </summary>
        public IEnumerable<IRobotLogEntryViewModel> Entries => entryCollection;

        public void SetLog(IRobotLog log)
        {
            Clear();

            foreach(var entry in log.Entries)
            {
                AddEntry(new RobotLogEntryViewModel(entry));
            }
        }



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
