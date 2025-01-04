using Application.Commands;
using Application.Filters;

namespace Application
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            try
            {
                string url = args[1];
                byte[] fileData;
                string contentType;

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                        throw new Exception("Cannot get file");


                    fileData = await response.Content.ReadAsByteArrayAsync();
                    contentType = response.Content.Headers.ContentType.MediaType;

                }

                var filter = FilterFactory.Create(contentType);
                var result = filter.Handle(fileData);


                var commandService = new CommandService(args, result);
                commandService.InitializeCommandContext();
                commandService.GenerateResults();


            }catch(Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}.");

            }
           

        }
    }
}
