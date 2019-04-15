using Robots.Gui.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Robots.Gui.Modules.Robots.RobotLog
{
    public class RobotLogViewModel : IRobotLogViewModel
    {
        private ObservableCollection<IRobotLogEntryViewModel> entryCollection = new ObservableCollection<IRobotLogEntryViewModel>();

        private IRobotLog log;

        /// <summary>
        /// IEnumerable to not make it editable outside
        /// </summary>
        public IEnumerable<IRobotLogEntryViewModel> Entries => entryCollection;

        public void SetLog(IRobotLog log)
        {
            if (this.log != null)
            {
                this.log.NewEntry -= log_NewEntry;
                this.log.EntriesCleared -= Log_EntriesCleared;
            }

            Clear();

            this.log = log;

            foreach(var entry in log.Entries)
            {
                AddEntry(new RobotLogEntryViewModel(entry));
            }

            log.NewEntry += log_NewEntry;
            log.EntriesCleared += Log_EntriesCleared;
        }

        private void Log_EntriesCleared(object sender, EventArgs e)
        {
            App.Current.Dispatcher.Invoke(() => {
                Clear();
            });
        }

        private void log_NewEntry(object sender, RobotLogNewEntryEventArgs e)
        {
            App.Current.Dispatcher.Invoke(() => {
                AddEntry(new RobotLogEntryViewModel(e.NewEntry));
            }); ;
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
