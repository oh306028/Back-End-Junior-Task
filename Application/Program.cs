using Application.Commands;
using Application.Filters;
using System.Net;

namespace Application
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                ValidateArguments(args);

                string url = args[1];
                var response = await GetFileAsync(url);
                byte[] fileData = await response.Content.ReadAsByteArrayAsync();
                string contentType = response.Content.Headers.ContentType.MediaType;


                var filter = FilterFactory.Create(contentType);
                var result = filter.Handle(fileData);


                var commandService = new CommandService(args, result);
                commandService.InitializeCommandContext();
                commandService.GenerateResults();


            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}.");

            }

        }


        private static void ValidateArguments(string[] args)
        {
            if (args.Length < 2 || string.IsNullOrEmpty(args.ElementAtOrDefault(1)))
                throw new Exception("Cannot process the file");
        }

        private static async Task<HttpResponseMessage> GetFileAsync(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot get file");

            return response;
        }




    }
}
