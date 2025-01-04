using Application.Models;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filters
{
    public class ZipFilter : IFilter
    {
        public IEnumerable<Participant> Handle(byte[] fileData)
        {
            using (var zipStream = new MemoryStream(fileData))
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase)) 
                    {
                        using (var entryStream = entry.Open())
                        {
                            var csvFilter = new CsvFilter();
                            var entryBytes = new byte[entry.Length]; 
                            entryStream.Read(entryBytes, 0, entryBytes.Length);
                            return csvFilter.Handle(entryBytes);
                        }
                    }
                }
            }

            throw new Exception("Cannot process the file");
        }
    }


}
