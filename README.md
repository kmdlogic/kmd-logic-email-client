﻿# KMD Logic Email Api Client ![Email icon](Email.png)

A dotnet client library for using Email module in KMD Logic platform through API.
## The purpose of the Email API

To allow products using Logic platform to send emails  

## EmailClient

Logic email client provides below options:
* Upload Attachments
* Upload Templates 
* Send Emails
  * Send simple text emails
  * Send email with attachments
  * Send email using (HTML) templates
  * Send scheduled emails
* Get Email Request Details

## Getting started in ASP.NET Core

To use this library in an ASP.NET Core application, 
add a reference to the [Kmd.Logic.Email.Client](https://www.nuget.org/packages/Kmd.Logic.Email.Client) nuget package, 
and add a reference to the [Kmd.Logic.Identity.Authorization](https://www.nuget.org/packages/Kmd.Logic.Identity.Authorization) nuget package.

## How to use Email client library

In projects or components where you need to send Email, add a NuGet package reference to [Kmd.Logic.Email.Client](https://www.nuget.org/packages/Kmd.Logic.Email.Client).

The `LogicTokenProviderFactory` authorizes access to the Logic platform through the use of a Logic Identity issued client credential. The authorization token is reused until it expires. You would generally create a single instance of `LogicTokenProviderFactory`.

The `EmailClient` accesses the Email service.

To get started:

1. Create a subscription in [Logic Console](https://console.kmdlogic.io). This will provide you with the `SubscriptionId`.
2. Request a client credential. Once issued you can view the `ClientId`, `ClientSecret` and `AuthorizationScope` in [Logic Console](https://console.kmdlogic.io).
3. Create an Email configuration. This will give you the `ConfigurationId`.
4. As soon as the configuration is approved by the Logic Admin, you can start sending emails using it.

**Note:** Please raise an [issue](https://dev.azure.com/kmddk/KMDLoGIC/_dashboards/dashboard/02f46530-28bb-4962-bc2a-a12eabfe383e) for configuration approval.

The simplest example to send a Email is:

```C#
using var httpClient = new HttpClient();
using var tokenProviderFactory = new LogicTokenProviderFactory(configuration.TokenProvider);
var emailClient = new EmailClient(httpClient, tokenProviderFactory, configuration.EmailOptions);

var emailResponse = await emailClient.SendEmail(new SendEmailRequestDetails()).ConfigureAwait(false);

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

Below sample console applications are included as references to show how Logic Email service can be used. You will need to provide the settings described above in `appsettings.json`.
* [Upload attachments](https://github.com/kmdlogic/kmd-logic-email-client/tree/dev/sample/Kmd.Logic.Email.Client.AttachmentsSample)
* [Upload templates](https://github.com/kmdlogic/kmd-logic-email-client/tree/dev/sample/Kmd.Logic.Email.Client.TemplateSample)
* [Send email](https://github.com/kmdlogic/kmd-logic-email-client/tree/dev/sample/Kmd.Logic.Email.Client.SendEmailSample)