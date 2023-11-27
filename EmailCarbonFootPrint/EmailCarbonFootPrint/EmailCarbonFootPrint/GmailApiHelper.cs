using EmailCarbonFootPrint;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;

public static class GmailApiHelper
{
    public static UserCredential GetCredential()
    {
        using (var stream = new FileStream(Constants.CredentialsFilePath, FileMode.Open, FileAccess.Read))
        {
            return GoogleCredentialProvider.GetCredential(stream);
        }
    }

    public static GmailService GetGmailService(UserCredential credential, string applicationName)
    {
        return GmailServiceInitializer.Initialize(credential, applicationName);
    }

    public static int GetMessageCount(GmailService gmailService, string labelName)
    {
        return GmailLabelManager.GetMessageCount(gmailService, labelName);
    }
}