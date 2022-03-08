using Kmd.Logic.Email.Client.ServicesMessages;
using Kmd.Logic.Identity.Authorization;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kmd.Logic.Email.Client.ConfigurationSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            InitLogger();

            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables()
                    .AddCommandLine(args)
                    .Build()
                    .Get<AppConfiguration>();

                await Run(config).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Caught a fatal unhandled exception");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void InitLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }

        private static async Task Run(AppConfiguration configuration)
        {
            var validator = new ConfigurationValidator(configuration);
            if (!validator.Validate())
            {
                return;
            }

            using var httpClient = new HttpClient();
            using var tokenProviderFactory = new LogicTokenProviderFactory(configuration.TokenProvider);
            var emailClient = new EmailCient(httpClient, tokenProviderFactory, configuration.EmailOptions);

            // Create MSExchange Configuration
            // Take configuration details from user
            Console.WriteLine("Enter Configuration name:");
            string configurationName = Console.ReadLine();

            Console.WriteLine("Enter From address:");
            string fromAddress = Console.ReadLine();

            Log.Information("Creating  MSExchange Configuration...");
            var configRequest = new MSExchangeConfigurationRequestDetails(configurationName, fromAddress);
            var configResult = await emailClient.CreateMSExchangeConfiguration(configRequest).ConfigureAwait(false);
            if (configResult == null)
            {
                Log.Error("Couldn't Create configuration");
                return;
            }
            else
            {
                Log.Information("Configuration created successfully...");
                Console.WriteLine(
                    "\nConfiguration ID: {0} \nFromAddress: {1}\nIsApproved ID : {2}",
                    configResult.Id,
                    configResult.FromAddress,
                    configResult.IsApproved);
            }
        }
    }
}
