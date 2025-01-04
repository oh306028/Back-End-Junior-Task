using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class MaxAgeCommand : ICommand
    {
        public void Execute(string[] args, IEnumerable<Participant> participants)
        {
            if (args.Length > 2)
                throw new ArgumentException("Invalid command");

            Console.WriteLine(participants.MaxBy(x => x.Age).Age);

        }
    }
}
