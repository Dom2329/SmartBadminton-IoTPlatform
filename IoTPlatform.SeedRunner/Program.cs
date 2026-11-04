
using IoTPlatform.Infrastructure.Data;
using IoTPlatform.Infrastructure.Seed;

namespace IoTPlatform.SeedRunner
{
    internal class Program
    {
        //----------------------------------------main method-----------------------
        static async Task Main(string[] args)
        {
            try
            {
                // create database connection
                var factory = new IoTPlatformDbContextFactory();

                using var context = factory.CreateDbContext(args);

                // create json loader
                var loader = new JsonSeedLoader(context);

                // locate json file
                string filePath = Path.Combine(
                    AppContext.BaseDirectory,
                    "devices.json"
                );

                // load badminton devices
                await loader.LoadDevicesAsync(filePath);

                Console.WriteLine("Badminton devices loaded successfully!");

                // show total devices
                Console.WriteLine("Total devices: " +
                    context.Devices.Count());
            }
           
catch (Exception ex)
{
    //----------------------------------------show detailed error-----------------------
    Console.WriteLine("Error: " + ex.Message);

    if (ex.InnerException != null)
    {
        Console.WriteLine("Details: " + ex.InnerException.Message);
    }
}


            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
