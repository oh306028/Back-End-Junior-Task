using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CommandService
    {
        private readonly string[] _args;
        private readonly IEnumerable<Participant> _participants;
        private CommandContext _commandContext;
        public CommandService(string[] args, IEnumerable<Participant> participants)
        {
            _args = args;
            _participants = participants;
        }


        public void InitializeCommandContext()
        {
            switch (_args[0])
            {
                case "count":
                    _commandContext = new CommandContext(new CountCommand());
                    break;
                case "max-age":
                    _commandContext = new CommandContext(new MaxAgeCommand());
                    break;
                default:
                    throw new ArgumentException("Invalid command");
            }        

        }

        public void GenerateResults()
        {
            _commandContext.ExecuteCommand(_args, _participants);
        }


    }
}
