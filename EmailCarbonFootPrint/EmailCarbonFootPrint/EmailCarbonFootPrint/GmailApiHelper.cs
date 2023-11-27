using EmailCarbonFootPrint;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;

public static class GmailApiHelper
{
    public static UserCredential GetCredential()
    {
        UserCredential credential;

        using (var stream = new FileStream(Constants.CredentialsFilePath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Constants.GmailScopes,
                Constants.UserIdentifier,
                System.Threading.CancellationToken.None
            ).Result;
        }

        return credential;
    }

    public static GmailService GetGmailService(UserCredential credential, string applicationName)
    {
        var gmailService = new GmailService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = applicationName,
        });

        return gmailService;
    }

    public static int GetMessageCount(GmailService gmailService, string labelName)
    {
        var userLabels = gmailService.Users.Labels.List(Constants.AuthenticatedUser).Execute().Labels;

        var targetLabel = userLabels.FirstOrDefault(label => label.Name == labelName);

        if (targetLabel != null)
        {
            var listRequest = gmailService.Users.Messages.List(Constants.AuthenticatedUser);
            listRequest.LabelIds = targetLabel.Id;

            var messages = listRequest.Execute();

            return messages?.Messages?.Count ?? 0;
        }

        return 0;
    }
}