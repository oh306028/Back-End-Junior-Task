using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Models
{
    public class ParticipantCsvMap : ClassMap<Participant>
    {
        public ParticipantCsvMap()
        {
            Map(m => m.Id).Name("participants/id");
            Map(m => m.Age).Name("participants/age");
            Map(m => m.Name).Name("participants/name");
            Map(m => m.Email).Name("participants/email");
            Map(m => m.WorkStart).TypeConverter<CsvDateTimeConverter>().Name("participants/workStart");
            Map(m => m.WorkEnd).TypeConverter<CsvDateTimeConverter>().Name("participants/workEnd");   
        }
    }
}
