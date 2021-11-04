using System;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Providers.CargoOASIS.Infrastructure.Handlers.Queries;
using NextGenSoftware.OASIS.API.Providers.CargoOASIS.Infrastructure.Services.HttpHandler;
using NextGenSoftware.OASIS.API.Providers.CargoOASIS.Models.Request;

namespace NextGenSoftware.OASIS.API.Providers.CargoOASIS.TestHarness
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Cargo TEST HARNESS");
            var handler = new GetShowcaseBySlugHandler(new HttpHandler());
            var response = await handler.Handle(new GetShowcaseBySlugRequestModel()
            {
                Slug = "our-world-the-oasis",
                SlugId = "d0dec9"
            });
        }
    }
}