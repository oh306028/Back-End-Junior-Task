using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Filters
{
    public class JsonFilter : IFilter
    {
        public IEnumerable<Participant> Handle(byte[] file)
        {
            string stringContent = Encoding.UTF8.GetString(file);   
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new DateTimeConverter() }

            };

            var result = JsonSerializer.Deserialize<ParticipantWrapper>(stringContent, options);    

            return result.Participants.ToList();   
        }

    }
}
