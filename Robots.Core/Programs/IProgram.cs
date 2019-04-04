using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.Programs
{
    public interface IProgram
    {
        string Name { get; set; }
        ulong Id { get; }

        event EventHandler<ProgramCommandEventArgs> OnCommandExecutionStart;
        event EventHandler<ProgramCommandEventArgs> OnCommandExecutionEnd;
        event EventHandler<ProgramEventArgs> OnProgramExecutionEnd;

        Task Start(IRobot robot);

        void AddCommand(IProgramCommand command);
        void RemoveCommand(IProgramCommand command);

        IEnumerable<IProgramCommand> Commands { get; }
    }
}
