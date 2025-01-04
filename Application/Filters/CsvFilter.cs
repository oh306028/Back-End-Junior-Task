using Application.Models;
using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filters
{
    public class CsvFilter : IFilter
    {
        public IEnumerable<Participant> Handle(byte[] file)
        {
            string csvContent = Encoding.UTF8.GetString(file);

            using (var reader = new StringReader(csvContent))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, 
            }))
            {
                csv.Context.RegisterClassMap<ParticipantCsvMap>();


                var records = csv.GetRecords<Participant>();              
                return records.ToList();
            }
        }
    }
}
