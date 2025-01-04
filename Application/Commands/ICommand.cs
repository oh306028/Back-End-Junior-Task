using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ICommand
    {
        void Execute(string [] args, IEnumerable<Participant> participants);
    }
}
