﻿using Kmd.Logic.Email.Client.Models;
using Kmd.Logic.Email.Client.ServicesMessages;
using Kmd.Logic.Email.Client.Types;
using Kmd.Logic.Identity.Authorization;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kmd.Logic.Email.Client
{
    /// <summary>
    /// Class to use the autogenerated client class to call APIs.
    /// </summary>
    public sealed class EmailClient : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly EmailOptions options;
        private readonly ITokenProviderFactory tokenProviderFactory;
        private InternalClient internalClient;
        private string bearerToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client to use. The caller is expected to manage this resource and it will not be disposed.</param>
        /// <param name="tokenProviderFactory">The Logic access token provider factory.</param>
        /// <param name="options">The required configuration options.</param>
        public EmailClient(
            HttpClient httpClient,
            ITokenProviderFactory tokenProviderFactory,
            EmailOptions options)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.tokenProviderFactory = tokenProviderFactory ?? throw new ArgumentNullException(nameof(tokenProviderFactory));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailClient"/> class using bearer token.
        /// </summary>
        /// <param name="httpClient">The HTTP client to use. The caller is expected to manage this resource and it will not be disposed.</param>
        /// <param name="options">The required configuration options.</param>
        /// <param name="bearerToken">Required access token to authenticate with Email module.</param>
        public EmailClient(
           HttpClient httpClient,
           string bearerToken,
           EmailOptions options)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.bearerToken = bearerToken ?? throw new ArgumentNullException(nameof(bearerToken));
        }

        /// <summary>
        /// Creates MSExchange Configuration.
        /// </summary>
        /// <param name="mSExchangeConfigurationRequestDetails">Configuration details to be created.</param>
        /// <returns>CreateCertificateResponse.</returns>
        public async Task<MSExchangeConfigurationResponse> CreateMSExchangeConfiguration(MSExchangeConfigurationRequestDetails mSExchangeConfigurationRequestDetails)
        {
            var client = this.CreateClient();
            var request = new MSExchangeConfigurationCreateRequest(
                mSExchangeConfigurationRequestDetails.FromAddress,
                mSExchangeConfigurationRequestDetails.ConfigurationName);
            using var configurationDetailsResponse = await client.CreateEmailConfigurationWithHttpMessagesAsync(
                 this.options.SubscriptionId,
                 request).ConfigureAwait(false);
            switch (configurationDetailsResponse?.Response?.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return configurationDetailsResponse.Body;

                case System.Net.HttpStatusCode.NotFound:
                    return null;

                case System.Net.HttpStatusCode.BadRequest:
                    return null;

                default:
                    throw new EmailException(configurationDetailsResponse?.Body?.ToString() ?? "Error accessing Email service.");
            }
        }

        /// <summary>
        /// Send Eamil.
        /// </summary>
        /// <param name="sendEmailRequestDetails">Send email detial request.</param>
        /// <returns>Email request Id.</returns>
        public async Task<SendEmailResponseDetails> SendEmail(SendEmailRequestDetails sendEmailRequestDetails)
        {
            var client = this.CreateClient();

            var emailRecipient = new RecipientEmail(
                    this.MapEmailRecipients(sendEmailRequestDetails?.Recipients?.To),
                    this.MapEmailRecipients(sendEmailRequestDetails?.Recipients?.Cc),
                    this.MapEmailRecipients(sendEmailRequestDetails?.Recipients?.Bcc));

            var request = new SendEmailRequest(
                sendEmailRequestDetails.ProviderConfigurationId,
                sendEmailRequestDetails.Importance,
                sendEmailRequestDetails.Subject,
                emailRecipient,
                sendEmailRequestDetails.Body,
                sendEmailRequestDetails.Attachment?.Select(x => new Attachment(x.AttachmentId)).ToList(),
                sendEmailRequestDetails.Schedule,
                new TemplateDetails(sendEmailRequestDetails?.Template?.TemplateId, sendEmailRequestDetails?.Template?.MergeData),
                sendEmailRequestDetails.CallbackUrl);

            var configurationDetailsResponse = await client.SendEmailWithHttpMessagesAsync(
                 this.options.SubscriptionId,
                 request).ConfigureAwait(false);

            switch (configurationDetailsResponse?.Response?.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return this.EmailResponse((SendEmailResponse)configurationDetailsResponse.Body);

                case System.Net.HttpStatusCode.NotFound:
                    return null;

                case System.Net.HttpStatusCode.BadRequest:
                    return null;

                default:
                    throw new EmailException(configurationDetailsResponse?.Body?.ToString() ?? "Error accessing Email service.");
            }
        }

        // Add attachment.
        // </summary>
        // <param name="attachmentRequestDetails">Attachment details to be created.</param>
        // <returns>Attachment Response.</returns>
        public async Task<AttachmentResponseDetails> AddAttachment(AttachmentRequestDetails attachmentRequestDetails)
        {
            var client = this.CreateClient();

            using var attachmentResponse = await client.SaveAttachmentWithHttpMessagesAsync(
                 this.options.SubscriptionId,
                 attachmentRequestDetails.ProviderConfigurationId,
                 attachmentRequestDetails.Attachment).ConfigureAwait(false);

            switch (attachmentResponse?.Response?.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return this.AttachmentResponse((AttachmentResponse)attachmentResponse.Body);

                case System.Net.HttpStatusCode.NotFound:
                    return null;

                default:
                    throw new EmailException(attachmentResponse?.Body?.ToString() ?? "Error accessing Email service.");
            }
        }

        /// <summary>
        /// Upload Template.
        /// </summary>
        /// <param name="templateRequestDetails">Template details to be uploaded.</param>
        /// <returns>Template Response.</returns>
        public async Task<TemplateResponseDetails> AddTemplate(TemplateRequestDetails templateRequestDetails)
        {
            var client = this.CreateClient();

            using var templateResponse = await client.SaveTemplateWithHttpMessagesAsync(
                 this.options.SubscriptionId,
                 templateRequestDetails.ProviderConfigurationId,
                 templateRequestDetails.Template).ConfigureAwait(false);

            switch (templateResponse?.Response?.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return this.TemplateResponse((TemplateResponse)templateResponse.Body);

                case System.Net.HttpStatusCode.NotFound:
                    return null;

                case System.Net.HttpStatusCode.BadRequest:
                    return null;

                default:
                    throw new EmailException(templateResponse?.Body?.ToString() ?? "Error accessing Email service.");
            }
        }

        /// <summary>
        /// Get all provider configurations.
        /// </summary>
        /// <returns>List of Provider Configurations.</returns>
        public async Task<IEnumerable<EmailProviderConfiguration>> GetAllProviderConfigurations()
        {
            var client = this.CreateClient();

            using (var configurationDetailsResponse = await client.GetAllProviderConfigurationsWithHttpMessagesAsync(
                 this.options.SubscriptionId).ConfigureAwait(false))
            {
                switch (configurationDetailsResponse?.Response?.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        return configurationDetailsResponse.Body;
                    default:
                        throw new EmailException(configurationDetailsResponse?.Body?.ToString() ?? "Invalid configuration provided to access Email service");
                }
            }
        }

        /// <summary>
        /// Get the information about email request.
        /// </summary>
        /// <param name="emailRequestDetails">Email request details.</param>
        /// <returns>EmailDetailsResponse.</returns>
        public async Task<EmailDetailsResponse> GetEmailRequestDetails(EmailRequestDetails emailRequestDetails)
        {
            var client = this.CreateClient();

            using (var emailDetailsResponse = await client.GetEmailDetailsWithHttpMessagesAsync(
                 emailRequestDetails.SubscriptionId, emailRequestDetails.RequestId).ConfigureAwait(false))
            {
                switch (emailDetailsResponse?.Response?.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        return emailDetailsResponse.Body;

                    case System.Net.HttpStatusCode.NotFound:
                        return null;

                    default:
                        throw new EmailException(emailDetailsResponse?.Body?.ToString() ?? "Error accessing email service.");
                }
            }
        }

        /// <summary>
        /// Disposing the rest of the classes.
        /// </summary>
        public void Dispose()
        {
            this.httpClient?.Dispose();
            this.tokenProviderFactory?.Dispose();
            this.internalClient?.Dispose();
        }

        private TemplateResponseDetails TemplateResponse(TemplateResponse body)
        {
            return new TemplateResponseDetails(body.TemplateId);
        }

        private AttachmentResponseDetails AttachmentResponse(AttachmentResponse body)
        {
            return new AttachmentResponseDetails(body.AttachmentId);
        }

        private IList<EmailAddress> MapEmailRecipients(IList<EmailAddressDetails> emails)
        {
            var lstEmail = new List<EmailAddress>();
            emails?.ToList().ForEach(x => lstEmail.Add(new EmailAddress(x.Email)));
            return lstEmail;
        }

        private SendEmailResponseDetails EmailResponse(SendEmailResponse body)
        {
            return new SendEmailResponseDetails(body.EmailRequestId);
        }

        /// <summary>
        /// Create internal client.
        /// </summary>
        /// <returns>InternalClient.</returns>
        private InternalClient CreateClient()
        {
            if (this.internalClient != null)
            {
                return this.internalClient;
            }

            TokenCredentials credentials;
            if (!string.IsNullOrEmpty(this.bearerToken))
            {
                credentials = new TokenCredentials(this.bearerToken);
                this.internalClient = new InternalClient(credentials)
                {
                    BaseUri = this.options.EmailServiceUri,
                };
            }
            else
            {
                var tokenProvider = this.tokenProviderFactory.GetProvider(this.httpClient);
                this.internalClient = new InternalClient(new TokenCredentials(tokenProvider))
                {
                    BaseUri = this.options.EmailServiceUri,
                };
            }

            return this.internalClient;
        }
    }
}
