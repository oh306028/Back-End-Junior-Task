using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filters
{
    public static class FilterFactory
    {
       public static IFilter Create(string fileExtension)
       {
            switch (fileExtension)
            {
                case "application/json":
                    return new JsonFilter();

                case "text/csv":
                    return new CsvFilter();

                case "application/zip":
                    return new ZipFilter(); 

                default:
                    throw new ArgumentException("Cannot process the file");


            }
       }



    }
}
