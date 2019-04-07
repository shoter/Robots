using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Robots.Gui.Commands
{
    public class ActionCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action<T> action;

        public ActionCommand(Action<T> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            Debug.Assert(parameter is T);
            return true;
        }

        public void Execute(object parameter)
        {
            Debug.Assert(parameter is T);

            action((T) parameter);
        }
    }
}
