using EmailCarbonFootPrint;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var credential = GmailApiHelper.GetCredential();
            var service = GmailApiHelper.GetGmailService(credential, Constants.ApplicationName);

            var inboxCount = GmailApiHelper.GetMessageCount(service, Constants.InboxLabel);
            var spamCount = GmailApiHelper.GetMessageCount(service, Constants.SpamLabel);
            var sentCount = GmailApiHelper.GetMessageCount(service, Constants.SentLabel);

            var carbonFootprint = EmailCarbonFootprint.CalculateCarbonFootprint(inboxCount, spamCount, sentCount);

            Console.WriteLine("Carbon Footprint Calculation:");
            Console.WriteLine($"Inbox Footprint: {carbonFootprint.Inbox} kg CO2");
            Console.WriteLine($"Spam Footprint: {carbonFootprint.Spam} kg CO2");
            Console.WriteLine($"Sent Footprint: {carbonFootprint.Sent} kg CO2");
            Console.WriteLine($"Total Footprint: {carbonFootprint.Total} kg CO2");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}