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
        private readonly Func<T, bool> canExecute;

        public ActionCommand(Action<T> action)
        {
            this.action = action;
        }

        public ActionCommand(Action<T> action, Func<T, bool> canExecute)
            : this(action)
        {
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null && parameter == null)
                return false;

            return canExecute?.Invoke((T) parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            Debug.Assert(parameter is T);

            action((T) parameter);
        }
    }
}
