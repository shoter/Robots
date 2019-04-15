using Robots.SDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Core.Programs
{
    public interface IProgram : INotifyPropertyChanged
    {
        string Name { get; set; }
        ulong Id { get; }

        void AddCommand(IProgramCommand command);
        void RemoveCommand(IProgramCommand command);

        IEnumerable<IProgramCommand> Commands { get; }
    }
}
