using Google.Apis.Gmail.v1;

namespace EmailCarbonFootPrint;

public static class GmailLabelManager
{
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