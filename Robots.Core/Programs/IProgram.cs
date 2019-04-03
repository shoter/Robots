using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.Programs
{
    public interface IProgram
    {
        event EventHandler<ProgramCommandEventArgs> OnCommandExecutionStart;
        event EventHandler<ProgramCommandEventArgs> OnCommandExecutionEnd;
        event EventHandler<EventArgs> OnProgramExecutionEnd;

        Task Start(IRobot robot);

        void AddCommand(ICommand command);
        void RemoveCommand(ICommand command);

        IEnumerable<ICommand> Commands { get; }
    }
}
