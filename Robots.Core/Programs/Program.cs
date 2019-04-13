using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Robots.Common;
using Robots.SDK;

namespace Robots.Core.Programs
{
    public class Program : IProgram, INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                notifyPropertyChanged();
            }
        }

        public ulong Id { get; }

        private static UniqueIdGenerator uniqueId = new UniqueIdGenerator();

        private List<IProgramCommand> CommandList { get; } = new List<IProgramCommand>();

        public IEnumerable<IProgramCommand> Commands => CommandList;

        public event EventHandler<ProgramCommandEventArgs> OnCommandExecutionStart;
        public event EventHandler<ProgramCommandEventArgs> OnCommandExecutionEnd;
        public event EventHandler<ProgramEventArgs> OnProgramExecutionEnd;
        public event PropertyChangedEventHandler PropertyChanged;

        public Program()
        {
            this.Id = uniqueId.Id;
            this.Name = $"Program {Id}";
        }

        public void AddCommand(IProgramCommand command)
        {
            CommandList.Add(command);
        }

        public void RemoveCommand(IProgramCommand command)
        {
            CommandList.Remove(command);
        }

        public async Task Start(IRobot robot)
        {
            foreach(var c in Commands)
            {
                OnCommandExecutionStart?.Invoke(this, new ProgramCommandEventArgs(robot, c));
                await c.Execute(robot);
                OnCommandExecutionEnd?.Invoke(this, new ProgramCommandEventArgs(robot, c));
            }

            OnProgramExecutionEnd?.Invoke(this, new ProgramEventArgs(robot));
        }

        public override string ToString() => Name;

        private void notifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
