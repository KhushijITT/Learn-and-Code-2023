using Google.Apis.Auth.OAuth2;

namespace EmailCarbonFootPrint;

public static class GoogleCredentialProvider
{
    public static UserCredential GetCredential(Stream stream)
    {
        return GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            Constants.GmailScopes,
            Constants.UserIdentifier,
            System.Threading.CancellationToken.None
        ).Result;
    }
}