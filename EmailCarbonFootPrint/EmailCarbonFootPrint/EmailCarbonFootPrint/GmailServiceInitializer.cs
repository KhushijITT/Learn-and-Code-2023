using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;

namespace EmailCarbonFootPrint;

public static class GmailServiceInitializer
{
    public static GmailService Initialize(UserCredential credential, string applicationName)
    {
        return new GmailService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = applicationName,
        });
    }
}