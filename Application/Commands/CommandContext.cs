using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CommandContext
    {
        private ICommand _currentCommand;

        public void SetCommand(ICommand command)
        {
            _currentCommand = command;
        }

        public CommandContext(ICommand currentCommand){
            _currentCommand = currentCommand;

        }

        public void ExecuteCommand(string[] args, IEnumerable<Participant> participants)
        {
            _currentCommand.Execute(args, participants);
        }

    }
}
