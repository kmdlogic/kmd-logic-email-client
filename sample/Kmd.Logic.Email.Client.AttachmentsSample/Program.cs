using Kmd.Logic.Email.Client.ServicesMessages;
using Kmd.Logic.Identity.Authorization;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kmd.Logic.Email.Client.AttachmentsSample
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
                    .AddUserSecrets<Program>()
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
            var emailClient = new EmailClient(httpClient, tokenProviderFactory, configuration.EmailOptions);

            Console.WriteLine("Please provider Configuration Id:");
            string configurationId = Console.ReadLine();

            int repeat = 0;
            do
            {
                Console.WriteLine("Please provide file path:");
                string filePath = Console.ReadLine();
                Stream attachmentFile;
                attachmentFile = new FileStream(filePath, FileMode.Open);

                // Creating attachment request
                Log.Information("Creating attachment request");
                var attachmentReq = new AttachmentRequestDetails(new Guid(configurationId), attachmentFile);
                Log.Information("Uploading attachment");
                var configResult = await emailClient.AddAttachment(attachmentReq).ConfigureAwait(false);
                if (configResult == null)
                {
                    Log.Error("Couldn't upload attachment");
                    return;
                }
                else
                {
                    Log.Information("Attachment uploaded successfully...");
                    Console.WriteLine("Attachment Id: {0} ", configResult.AttachmentId);
                }

                Console.WriteLine("\nPlease press 1 to continue with another attachment:");
                repeat = Convert.ToInt32(Console.ReadLine());
            }
            while (repeat == 1);
        }
    }
}
