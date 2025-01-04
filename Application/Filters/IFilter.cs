using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filters
{
    public interface IFilter
    {
        public IEnumerable<Participant> Handle(byte[] file);

    }
}
