using Google.Apis.Gmail.v1;

namespace EmailCarbonFootPrint;

public static class Constants
{
    public static string[] GmailScopes = { GmailService.Scope.GmailReadonly };

    public const string CredentialsFilePath = "C:/Users/khushi.j/Downloads/credentials.json";

    public const string UserIdentifier = "user";

    public const string AuthenticatedUser = "me";

    public const string ApplicationName = "CarbonFootPrintEvaluator";

    public const string InboxLabel = "INBOX";

    public const string SpamLabel = "SPAM";

    public const string SentLabel = "SENT";
}