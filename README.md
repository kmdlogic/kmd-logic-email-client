# KMD Logic Email Api Client ![Email icon](Email.png)

A dotnet client library for using Email module in KMD Logic platform through API.
## The purpose of the Email API

To allow products using the Logic platform to **send email using custom email domain address**  

## EmailClient

The Logic EmailClient provides options to:
* Upload Attachment
* Upload Template 
* Send Email
  * Send simple text email
  * Send email with attachment
  * send email using (HTML) template
  

## Getting started in ASP.NET Core

To use this library in an ASP.NET Core application, 
add a reference to the [Kmd.Logic.Email.Client](https://www.nuget.org/packages/Kmd.Logic.Email.Client) nuget package, 
and add a reference to the [Kmd.Logic.Identity.Authorization](https://www.nuget.org/packages/Kmd.Logic.Identity.Authorization) nuget package.

## How to use Email client library

In projects or components where you need to access send Email, add a NuGet package reference to [Kmd.Logic.Email.Client](https://www.nuget.org/packages/Kmd.Logic.Email.Client).

The `LogicTokenProviderFactory` authorizes access to the Logic platform through the use of a Logic Identity issued client credential. The authorization token is reused until it expires. You would generally create a single instance of `LogicTokenProviderFactory`.

The `EmailClient` accesses the Email service.

To get started:

1. Create a subscription in [Logic Console](https://console.kmdlogic.io). This will provide you the `SubscriptionId`.
2. Request a client credential. Once issued you can view the `ClientId`, `ClientSecret` and `AuthorizationScope` in [Logic Console](https://console.kmdlogic.io).
3. Create a Email configuration. This will give you the `ConfigurationId`.

The simplest example to send a Email is:

```csharp
using var httpClient = new HttpClient();
using var tokenProviderFactory = new LogicTokenProviderFactory(configuration.TokenProvider);
var emailClient = new EmailClient(httpClient, tokenProviderFactory, configuration.EmailOptions);

var sendEmailRequest = new SendEmailRequestDetails(
    providerConfigurationId: configuration.ProviderConfigurationId,
    recipients: new RecipientEmailDetails(
            [
                {
                    email = " To Email Addres 1"
                },
                {
                    email = "To Email Addres 2"
                }
            ],
            [
                {
                    email = " Cc Email Addres 1"
                },
                {
                    email = "Cc Email Addres 2"
                }
            ],
            [
                {
                    email = "Bcc Email Addres 1"
                },
                {
                    email = "Bcc Email Addres 2"
                }
            ]),
    body: "Hello, world!",
    subject: "Email subject",
    attachment: new AttachmentDetails  [
                {
                    attachmentId: new Guid("00000000-0000-0000-0000-000000000000")
                }
            ],
    schedule: null,
    template: new TemplateData(
    {
        templateId: new Guid("00000000-0000-0000-0000-000000000000"),
        mergeData: {}
    }
    ),
    callbackUrl: "provide your callback Url")

var emailResponse = await emailClient.SendEmail(sendEmailRequest).ConfigureAwait(false);

```
The simplest example for upload attachment is:

```csharp
using var httpClient = new HttpClient();
using var tokenProviderFactory = new LogicTokenProviderFactory(configuration.TokenProvider);
var emailClient = new EmailClient(httpClient, tokenProviderFactory, configuration.EmailOptions);

 var attachmentRequest = new AttachmentRequestDetails(new Guid(configurationId), attachmentFile);
result = await emailClient.AddAttachment(attachmentRequest).ConfigureAwait(false)
```

The simplest example for upload template is:

```csharp
using var httpClient = new HttpClient();
using var tokenProviderFactory = new LogicTokenProviderFactory(configuration.TokenProvider);
var emailClient = new EmailClient(httpClient, tokenProviderFactory, configuration.EmailOptions);

 var attachmentRequest = new TemplateRequestDetails(new Guid(configurationId), templateFile);
result = await emailClient.AddAttachment(attachmentRequest).ConfigureAwait(false)
```

## Sample application
## How to configure the Email client

Perhaps the easiest way to configure the Email client is from Application Settings.

```json
{
  "TokenProvider": {
    "ClientId": "",
    "ClientSecret": "",
    "AuthorizationScope": ""
  },
  "EmailOptions": {
    "SubscriptionId": ""
  }
}
```

## Upload attachment

A [simple console application](https://github.com/kmdlogic/kmd-logic-email-client/tree/dev/sample/Kmd.Logic.Email.Client.AttachmentsSample) is included to demonstrate how to call Logic Emai API to `upload attachment file`. You will need to provide the settings described above in `appsettings.json`.

When you run this you should see the attachment Id printed to the console.

## Upload template

A [simple console application](https://github.com/kmdlogic/kmd-logic-email-client/tree/dev/sample/Kmd.Logic.Email.Client.TemplateSample) is included to demonstrate how to call Logic Emai API to `upload template` . You will need to provide the settings described above in `appsettings.json`.

When you run this you should see the email Request Id printed to the console.

## Send email

A [simple console application](https://github.com/kmdlogic/kmd-logic-email-client/tree/dev/sample/Kmd.Logic.Email.Client.SendEmailSample) is included to demonstrate how to call Logic Emai API to `send email`. You will need to provide the settings described above in `appsettings.json`.

When you run this you should see the email Request Id printed to the console.
