using EmailCarbonFootPrint;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            RunEmailCarbonFootprintCalculation();
        }
        catch (Exception ex)
        {
            HandleApplicationException(ex);
        }
    }

    private static void RunEmailCarbonFootprintCalculation()
    {
        var credential = GmailApiHelper.GetCredential();
        var service = GmailApiHelper.GetGmailService(credential, Constants.ApplicationName);

        var inboxCount = GmailApiHelper.GetMessageCount(service, Constants.InboxLabel);
        var spamCount = GmailApiHelper.GetMessageCount(service, Constants.SpamLabel);
        var sentCount = GmailApiHelper.GetMessageCount(service, Constants.SentLabel);

        var carbonFootprint = CarbonFootprintCalculator.CalculateCarbonFootprint(inboxCount, spamCount, sentCount);

        PrintCarbonFootprintResults(carbonFootprint);
    }

    private static void HandleApplicationException(Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    private static void PrintCarbonFootprintResults(EmailCarbonFootprint carbonFootprint)
    {
        Console.WriteLine("Email Carbon Footprint Calculation:");
        Console.WriteLine($"Inbox Footprint: {carbonFootprint.Inbox} kg CO2");
        Console.WriteLine($"Spam Footprint: {carbonFootprint.Spam} kg CO2");
        Console.WriteLine($"Sent Footprint: {carbonFootprint.Sent} kg CO2");
        Console.WriteLine($"Total Footprint: {carbonFootprint.Total} kg CO2");
    }
}