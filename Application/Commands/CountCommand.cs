using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CountCommand : ICommand
    {
        public void Execute(string[] args, IEnumerable<Participant> participants)
        {

            if (args.Length > 4)
                throw new ArgumentException("Invalid command");

            if (args.Length < 3)
            {
                Console.WriteLine(participants.Count());
                return;
            }


            var commandFilter = args[2];
            const string greaterThan = "--age-gt";
            const string lessThan = "--age-lt";



            if (!commandFilter.Equals(greaterThan) && !commandFilter.Equals(lessThan))
                throw new ArgumentException("Invalid command");


            if (!int.TryParse(args[3], out int age))
                throw new ArgumentException("Invalid command");


            if (commandFilter == greaterThan)
            {
                Console.WriteLine(participants.Where(x => x.Age > age).Count());

            }
            else
            {
                Console.WriteLine(participants.Where(x => x.Age < age).Count());

            }


        }
    }
}
