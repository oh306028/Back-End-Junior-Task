using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ParticipantWrapper
    {
        public IEnumerable<Participant> Participants { get; set; } = new List<Participant>();
    }
}
