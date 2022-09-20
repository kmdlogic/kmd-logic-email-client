using Kmd.Logic.Email.Client.ServicesMessages;
using Kmd.Logic.Identity.Authorization;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kmd.Logic.Email.Client.SendEmailSample
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

            Log.Information("Creating email send request...");
            var sendEmailRequest = new SendEmailRequestDetails(
               providerConfigurationId: configuration.ProviderConfigurationId,
               importance: configuration.Importance,
               recipients: new RecipientEmailDetails(
                   AppConfiguration.ToEmailRecipients(),
                   AppConfiguration.CcEmailRecipients(),
                   AppConfiguration.BccEmailRecipients()),
               body: configuration.Body,
               subject: configuration.Subject,
               attachment: null,
               schedule: null,
               template: new TemplateData(configuration.TemplateId, configuration.MergeData),
               callbackUrl: null);

            Log.Information("Sending email send request...!");
            var emailResponse = await emailClient.SendEmail(sendEmailRequest).ConfigureAwait(false);

            if (emailResponse == null)
            {
                Log.Error("Couldn't send email");
                return;
            }
            else
            {
                Log.Information("Sending email successfull.");
                Console.WriteLine("Email request Id : {0}", emailResponse.EmailRequestId);
            }
        }
    }
}
